    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Xml;
    namespace Wcf
    {
    public class SilverlightFaultAttribute : Attribute, IServiceBehavior
    {
        #region IServiceBehavior Members
        public void AddBindingParameters(ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Trace.WriteLine(" */*/*/* ApplyDispatchBehavior");
            foreach (var t in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = t as ChannelDispatcher;
                if ((channelDispatcher == null)) continue;
                foreach (var dispatcher2 in channelDispatcher.Endpoints)
                {
                    var dispatchRuntime = dispatcher2.DispatchRuntime;
                    dispatchRuntime.MessageInspectors.Add(new SilverlightFaultMessageInspector());
                }
            }
        }
        public class SilverlightFaultMessageInspector : IDispatchMessageInspector
        {
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
                if (reply.IsFault)
                {
                    Trace.WriteLine(" */*/*/* reply.IsFault");
                    Trace.WriteLine(reply);
                    var property = new HttpResponseMessageProperty();
                    // Here the response code is changed to 200.
                    property.StatusCode = System.Net.HttpStatusCode.OK;
                    reply.Properties[HttpResponseMessageProperty.Name] = property;
                    MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                    Message copy = buffer.CreateMessage();  // Create a copy to work with
                    reply = buffer.CreateMessage();         // Restore the original message 
                    object faultDetail = ReadFaultDetail(copy);
                    Exception exception = faultDetail as Exception;
                    Trace.WriteLine(exception);
                }
            }
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                // Do nothing to the incoming message.
                return null;
            }
            private static object ReadFaultDetail(Message reply)
            {
                const string detailElementName = "Detail";
                using (XmlDictionaryReader reader = reply.GetReaderAtBodyContents())
                {
                    // Find <soap:Detail>
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.LocalName == detailElementName)
                        {
                            break;
                        }
                    }
                    // Did we find it?
                    if (reader.NodeType != XmlNodeType.Element || reader.LocalName != detailElementName)
                    {
                        return null;
                    }
                    // Move to the contents of <soap:Detail>
                    if (!reader.Read())
                        return null;
                    // Deserialize the fault
                    NetDataContractSerializer serializer = new NetDataContractSerializer();
                    try
                    {
                        return serializer.ReadObject(reader);
                    }
                    catch (FileNotFoundException)
                    {
                        // Serializer was unable to find assembly where exception is defined 
                        return null;
                    }
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        #endregion
    }
    }
