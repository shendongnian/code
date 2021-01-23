    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using Demo.MessageInspector;
    using Demo.Utilities;
    namespace Demo.WebServices
    {
        public class MyWebService : IMyWebService, IServiceBehavior
        {
            public void MyWebServiceMethod()
            {
                // get the activityId from the incoming message properties
                var activityIdProperty = OperationContext.Current.IncomingMessageProperties
                    .FirstOrDefault(property => property.Key == Properties.ActivityId.ToString());
                // create an empty Guid
                Guid activityId = new Guid();
                if (activityIdProperty.Value != null)
                {
                    // replace the empty Guid with the activityId
                    activityId = (Guid)activityIdProperty.Value;
                }
                bool success = DoSomething();
                if (!success)
                    MyLog.Message("Error happened in MyWebServiceMethod", activityId);
            }
            private bool DoSomething()
            {
                // TODO: implement
                return false;
            }
            public void AddBindingParameters(
              ServiceDescription serviceDescription,
              ServiceHostBase serviceHostBase,
              System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
              BindingParameterCollection bindingParameters
            )
            {
                return;
            }
            public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
                ServiceHostBase serviceHostBase)
            {
                foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
                {
                    foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                    {
                        var messageInspector = new DemoMessageInspector();
                        epDisp.DispatchRuntime.MessageInspectors.Add(messageInspector);
                    }
                }
            }
            public void Validate(ServiceDescription serviceDescription, 
                ServiceHostBase serviceHostBase)
            {
                // TODO: implement validation
                //throw new NotImplementedException();
            }
        }
    }
    namespace Demo.MessageInspector
    {
        public class DemoMessageInspector : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref Message request, 
                IClientChannel channel, InstanceContext instanceContext)
            {
                Guid activityId = Guid.NewGuid();
                // add the activityId to the incoming message properties
                OperationContext.Current.IncomingMessageProperties
                    .Add(Properties.ActivityId.ToString(), activityId);
            
                MyLog.Message("AfterReceiveRequest", activityId);
                return activityId;
            }
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
                Guid activityId = (Guid)correlationState;
                MyLog.Message("BeforeSendReply", activityId);
            }
        }
    }
    namespace Demo.Utilities
    {
        public enum Properties
        {
            ActivityId
        }
        public class MyLog
        {
            internal static void Message(string p, Guid guid)
            {
                File.AppendAllText(@"C:\Temp\log.txt", 
                    String.Format("{0} {1} {2}\r\n", DateTime.Now, p, guid));
            }
        }
    }
