    public class MainForm : Form
    {
        public void YourMethod()
        {
            ///
        }
    }
    
    public class UserControl
    {
        private readonly MainForm _MainForm;
    
        public UserControl(MainForm mainForm)
        {
            _MainForm = mainForm;
    
            ///add event for checkbox
        }
    
        private void Checkbox_Clicked(object Sender, EventArgs e)
        {
            _MainForm.YourMethod();
        }
    
    }
