    public class utility
    {
    
    public static void MyTextBoxes(Control container, string CommandName){
            foreach (Control c in container.Controls){
            MyTextBoxes(c, CommandName);        
    
            if(c is TextBox){ 
              switch (CommandName)
              {
                case "Clear":
                    c.Text = "";   
                    break;
                case "ReadOnly":
                    ((TextBox)c).ReadOnly = true;
                    break;
              }  
                
            }   
        }    
    }
