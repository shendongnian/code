    public partial class Form1 : Form
    {
        public string[,] ParticipantX;
        public Form1()
        {
            InitializeComponent();
            Class1.SendArray += new EventHandler<MyArgs>(GetArray);
        }
        public void GetArray(object sender, MyArgs ea)
        {
            this.Invoke(new MethodInvoker(
                delegate()
                {
                  ParticipantX = ea.myArray;
                }));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Class1 t = new Class1();
            t.ParsedataMethod();
        }
    }
    public class MyArgs : EventArgs
    {
        public string[,] myArray { get; set; }
    }
