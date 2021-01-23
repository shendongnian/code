            ...
            try
            {    
                Client.Self.InstantMessage(Client.Self.Name, g.Value, ntc.Subject + "|"  
                    + ntc.Message, UUID.Zero, InstantMessageDialog.GroupNotice, 
                    InstantMessageOnline.Online, Vector3.Zero, UUID.Zero, 
                    ntc.SerializeAttachment()); 
            } 
            catch(Exception e)
            {
                Debug.WriteLine("Exception while calling InstantMessage: {0}", e.ToString());
            }
            Thread.Sleep(2000);
            ...
