    public class utility
    {
    
    public static void ClearTextBoxes(Form myform){
            foreach (Control c in myform.Controls){        
    
            if(c is TextBox){   
                c.Text = "";   
            }   
        }    
    }
