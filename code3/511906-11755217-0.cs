     protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData) 
    {
        
           if(KeyData == Keys.Right)
           {
            //Move Right
             return true;
             }
            else
            {
             return base.ProcessCmdKey(msg, keyData);
            }
        
     }
