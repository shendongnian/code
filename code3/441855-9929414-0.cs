    public class MyMediator
    {
        Form mainForm {get;set;}
        Form settingsForm{get;set;}
        public MyMediator()
        {
            mainForm = new MainForm(this);
            mainForm.Show();
        }
        ...
    
        public FocusMainForm() // call this from settings form
        {
            mainForm.TopMost = true;
        }
    }
