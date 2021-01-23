    public class StegApp
    {
          public DatabaseEntities context;
          //other properties
          public StegApp()
          {
               //assuming your DatabaseEntities class inherits from DbContext. 
               //You should create other constructors that allow you to set options
               //like lazy loading and mappings
               this.context = new DatabaseEntities(); 
          } 
          //ASSUMING YOUR RetrieveLogs.RetrieveMessages() function returns 
          //a Message object. replace this type with whatever type the
          //RetrieveLogs.RetrieveMessages() method returns.
          public Message RetrieveKeyFn (string username, string password)
          {
              
              BusinessObjects.User p = RetreiveLogs.AuthenitcateCredentials(username,password);
              if (p != null)
              {
                  var message = RetrieveLogs.RetrieveMessages(p.UserId);
                  if (message == null)
                      // handle behavior for no messages. In this case 
                      // I will just create a new Message object with a -1 LogId
                      return new Message {LogId =-1};
                  else
                      return message;
              }
              else
                  //handle behavior when the user is not authenticated. 
                  //In this case I throw an exception
                  throw new Exception();
              
          }
         //on your button click handler, do something like:
         // try 
         // {
         //     var message = RetrieveKeyFn(txtUsername.Text.Trim(), txtPassword.Text.Trim());
         //     if (message.LogId == -1)
         //         DisplayLogs.Text = "Sorry No messages for you recorded in Database, your correspondant might have chose not to record the entry";
         //     else
         //     {
         //         MessageBox.Show("Log Id = " + message.LogId)
         //         etc. etc. etc.
         //     }
         // }
         // catch
         // {
         //       MessageBox.Show ("user is not authenticated");
         // }
    }
