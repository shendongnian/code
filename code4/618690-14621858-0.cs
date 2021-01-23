    using  (MyServ.ServiceClient  proxy = new  MyServ.ServiceClient ())
     {
         using  (new  System.ServiceModel.OperationContextScope (proxy.InnerChannel))
         {
             MessageHeader  head = MessageHeader .CreateHeader("Authorization" , "http://yournamespace.com/v1" , data);
             OperationContext .Current.OutgoingMessageHeaders.Add(head);
         }
     }
