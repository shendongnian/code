    public class MyForm : Form
    {
        protected readonly string setting;
        public MyForm(string setting)
        {
            this.setting = setting;
        }
    }
    // to open
    (new MyForm("event1")).Show();
