        AlertMessagesQuery = 
          from alertMessage in this.context.AlertMessages 
          where alertMessage.UserId=UserId                                               
          select new 
          {
             alertMessage.PAM_ShortMessage, 
             alertMessage.PAM_LongMessage, 
             alertMessage.PAM_LongMessageRemote, 
             LinkVariables = from linkVariable in this.context.AlertMessageLinks 
                             from user in this.context.AlertMessageUsers 
                             where user.PAMU_PAM_ID == linkVariable.PAML_PAM_ID && user.PAMU_UserId == UserId 
                             select new  
                             { 
                                 Name = linkVariable.PAML_SessionVariableName, 
                                 Value = linkVariable.PAML_SessionVariableValue 
                             }) 
          }; 
        var alertMessageResults = 
          from message in AlertMessagesQuery.AsEnumerable()
          select new AlertMessageResult 
          {
            PAM_ShortMessage = mesage.PAM_ShortMessage,
            PAM_LongMessage = message.PAM_LongMessage,
            PAM_LongMessageRemote = message.PAM_LongMessageRemote,
            LinkVariables = (from variable in message.LinkVariables
                            select new LinkVariable { Name=variable.Name, Value = variable.Value})
                            .ToList()
          };
       return alertMessageResults.ToList();
