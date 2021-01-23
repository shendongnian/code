    public partial class Form1 : Form
     {
                         
      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
         if (keyData == (Keys.LWin | Keys.Up))//Left windows key + up arrow
           {
                            
               FormBorderStyle = FormBorderStyle.FixedDialog;
               return true;
            }
        
        if (keyData == Keys.Escape) //Form will call its close method when we click Escape.
            Close();
        
            return base.ProcessCmdKey(ref msg, keyData);
       }
    }
