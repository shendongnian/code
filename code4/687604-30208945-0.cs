       public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
      
            if (reply.IsFault)
            {
                // Create a copy of the original reply to allow default WCF processing
                MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                Message copy = buffer.CreateMessage();  // Create a copy to work with
                reply = buffer.CreateMessage();         // Restore the original message 
                MessageFault faultex = MessageFault.CreateFault(copy, Int32.MaxValue); //Get Fault from Message
                FaultCode codigo = faultex.Code;
                //if (faultex.HasDetail)... //More details
                    
                buffer.Close(); 
