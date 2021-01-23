    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.ServiceModel.Dispatcher;
    using System.ServiceModel.Channels;
    using System.ServiceModel;
    using System.Xml;
    
    namespace your_namespace
    {
    
    
        /// <summary>
        /// /************************************
        /// * 
        /// * Creating Message inspector for 
        /// * updating all outgoing messages with Caller identifier header
        /// * read http://msdn.microsoft.com/en-us/magazine/cc163302.aspx
        /// * for more details
        /// * 
        /// *********************/
        /// </summary>
        public class CredentialsMessageInspector : IDispatchMessageInspector,
            IClientMessageInspector
        {
            public object AfterReceiveRequest(ref Message request,
                IClientChannel channel,
                InstanceContext instanceContext)
            {
                return null;
            }
    
            public void BeforeSendReply(ref Message reply, object
                correlationState)
            {
    #if DEBUG
                //// Leave empty 
                //MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                //Message message = buffer.CreateMessage();
                ////Assign a copy to the ref received
                //reply = buffer.CreateMessage();
    
    
                //StringWriter stringWriter = new StringWriter();
                //XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                //message.WriteMessage(xmlTextWriter);
                //xmlTextWriter.Flush();
                //xmlTextWriter.Close();
    
                //String messageContent = stringWriter.ToString();
    #endif             
            }
    
            public void AfterReceiveReply(ref Message reply, object
                correlationState)
            {
    #if DEBUG
                //// Leave empty 
                //MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                //Message message = buffer.CreateMessage();
                ////Assign a copy to the ref received
                //reply = buffer.CreateMessage();
    
    
                //StringWriter stringWriter = new StringWriter();
                //XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                //message.WriteMessage(xmlTextWriter);
                //xmlTextWriter.Flush();
                //xmlTextWriter.Close();
    
                //String messageContent = stringWriter.ToString();
    #endif
            }
    
            public object BeforeSendRequest(ref Message request,
                IClientChannel channel)
            {
                request = CredentialsHelper.AddCredentialsHeader(ref request);
                return null;
            }
    
            #region IDispatchMessageInspector Members
         
            #endregion
        }
    }
