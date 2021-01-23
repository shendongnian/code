    public class AdminForm : Form
    {
         
            public AdminForm(MainForm mainForm)
            {
                
                  mainForm.Controls["LogInAsAdminMenuItem"].Enabled = true;
    
            }
    
    }
