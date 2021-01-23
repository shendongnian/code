    public class Form1 : Form
    {
        public SwitchForms VisibilityHelper { get; set; }
        public Form2 OtherForm { get; set; }
        public Form1()
        {
           OtherForm = new Form2();
           VisibilityHelper = new SwitchForms(this, OtherForm 5);
           
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            VisibilityHelper.Dispose();
        }
    }
