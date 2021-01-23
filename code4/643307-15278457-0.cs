    public class ChatApp : IChat
    {
       string member;
       Form1 form;
       public ChatApp(string member, Form1 form)
       {
            this.member = member;
            this.form = form;
       }
       public void Join(string member)
       {
           Console.WriteLine("[{0} joined]", member);
       }
       public void Chat(string member, string msg)
       {
           try
           {                      
                form.SetLogText("eureka");
           }
           catch (Exception ex)
           {    
               MessageBox.Show(ex.Message.ToString());    
           }
       }
       public void Leave(string member)
       {
           Console.WriteLine("[{0} left]", member);
       }
    }
