    oublic interface IMyInterface
    {
        int Property1 { get; }
        int Property2 { get; }
    }
    public partial class Form1 : Form, IMyInterface
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Property1 { get; set; }
        int Property2 { get; set; }
    }
    public class SomeClass
    {
        public void SomeMethod(IMyInterface readOnlyForm)
        {
        }
    }
