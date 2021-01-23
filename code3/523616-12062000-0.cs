    public partial class Form1 : Form
    {
        public Label Label1 { get; set; }
        public void Caller()
        {
            MyClass cls = new MyClass();
            cls.Form1 = this;
            cls.DoSomeJob();
        }
    }
    public class MyClass
    {
        public Form1 Form1 { get; set; }
        public void DoSomeJob()
        {
            Form1.Label1.Text = "Some text...";
        }
    }
