    using (OperationContextScope scope = new OperationContextScope(wcfClient.InnerChannel))
          {
            MessageHeader header
              = MessageHeader.CreateHeader(
              "Service-Bound-CustomHeader",
              "http://Microsoft.WCF.Documentation",
              "Custom Happy Value."
              );
            OperationContext.Current.OutgoingMessageHeaders.Add(header);
    
            // Making calls.
            Console.WriteLine("Enter the greeting to send: ");
            string greeting = Console.ReadLine();
    
            //Console.ReadLine();
            header = MessageHeader.CreateHeader(
                "Service-Bound-OneWayHeader",
                "http://Microsoft.WCF.Documentation",
                "Different Happy Value."
              );
            OperationContext.Current.OutgoingMessageHeaders.Add(header);
    
            // One-way
            wcfClient.Push(greeting);
            this.wait.WaitOne();
    
            // Done with service. 
            wcfClient.Close();
            Console.WriteLine("Done!");
            Console.ReadLine();
          }
