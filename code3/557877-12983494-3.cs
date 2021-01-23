     public class TextBoxWrapper
           public void EnablePropertyNotification(object sender, EventArgs args) 
           {
              TextBox1.Enabled = true ; //Enables textbox when event is raised.
           }
           public TextBoxWrapper()
           {
             class1Instance.subscribe+=EnablePropertyNotification ;
           }
