     List<string> personmessages = new List<string>();
     foreach (string i in messages)
     {  
         SDKRecordset PersoninboundSet = IQSDK.CreateRecordset("R_PERSON", "", "PK_R_PERSON = "+i ,"" );
         if (PersoninboundSet != null && PersoninboundSet.RecordCount > 0)
         {
    
             PersoninboundSet.MoveFirst();
    
             do
             {
                 string firstname = PersoninboundSet.Fields["FIRSTNAME"].Value.ToString();
                 string lastname = PersoninboundSet.Fields["LASTNAME"].Value.ToString();
    
                 personmessages.Add(firstname);
                 personmessages.Add(lastname);
    
                 PersoninboundSet.MoveNext();
    
             }
             while (!PersoninboundSet.EOF);
         } 
         else 
         {
             // *this* i could not be found
             messages.Add("Error, didn't work.");
             return messages;// null;
         }
     }
     return personmessages; // after we've processed *all* messages
    
