    public string SavePoint
    {
       get
       {
           string settings = "";
           string archive = "";
           if (rb_Backup.Checked)
           {
               settings = "backup";
           }
           else if (rb_Restore.Checked)
           {
               settings = "restore";
           }
           else if (rb_Sync.Checked)
           {
               settings = "sync";
           }
           if (cb_Archive.Checked)
           {
               archive = "true";
           }
           else
           {
               archive = "false";
           }
           string savePoint = txt_From.Text + "\r\n" + txt_To.Text + "\r\n" + settings + "\r\n" + archive;
           return savePoint;
       }
    }
