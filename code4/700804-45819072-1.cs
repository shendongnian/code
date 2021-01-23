    Using System.Configuration; 
   
    Properties.Settings.Default.strinconn = txt_stringconn.Text;
    Properties.Settings.Default.Save ();
    Properties.Settings.Default.Upgrade ();
    MessageBox.Show ("Saved Settings");
    Application.Restart ();
