    public class SearchForm:Form
    {
        private MainForm _callerForm;
        public void SearchForm(MainForm callingForm)
        {
             InitializeComponent();
             _callerForm = callingForm;
             _callerForm.Enabled = false;
        }
        // ...  somewhere in this class
        _callerForm.Enabled = true;
        this.Hide();
        // ....
    }
