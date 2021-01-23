    public class MyUserControl : UserControl
        {
               public TextBox MyTextBox 
               {
                   get
                   {
                      return txtBox1;
                   }
                   set
                   {
                       txtBox1 = value;
                   } 
               }
        }
