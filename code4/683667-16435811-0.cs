    public class MainForm : Form
    {
       SDKCommunication sdkcommunication = new SDKCommunication();
    
       public MainForm()
       { 
       
       }
       private void Button1_Click(oject sender, EventArgs e)
       {
          sdkcommunication.method("Test")
       }
    }
