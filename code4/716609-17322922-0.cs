    List<string> personmessages = new List<string>();
    List[] messageArray = new List[messages.length()];
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
     messageArray[i] =  personmessages;
    }
    return messageArray;
