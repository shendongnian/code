    public partial class MainForm :Form, InterfacePareto //My main form inheriting Form class and interface
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public string myTest
        {
            get { return herpTxt.Text; }
            set { herpTxt.Text = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //On button click create MyWorkingOutClass instance and pass MainForms instance
            MyWorkingOutClass mc = new MyWorkingOutClass(this); 
            //After this line text box content will change
            mc.Testtime();
        }
    }
    
    //Changed modifier to public
    public interface InterfacePareto
    {
        string myTest { get; set; }
    }
    
    //Changed modifier to public
    public class MyWorkingOutClass
    {
        private readonly InterfacePareto pare;
        public MyWorkingOutClass(InterfacePareto pare)
        {
            this.pare = pare;
        }
        //Changed modifier to public
        public void Testtime()
        {
            string firstName = pare.myTest;
            pare.myTest = firstName + " extra";
        }
    }
