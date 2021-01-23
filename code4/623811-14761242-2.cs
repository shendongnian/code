    public class utility
    {
    
    public static void ClearTextBoxes(Control container){
            foreach (Control c in container.Controls){
            ClearTextBoxes(c);        
    
            if(c is TextBox){   
                c.Text = "";   
            }   
        }    
    }
