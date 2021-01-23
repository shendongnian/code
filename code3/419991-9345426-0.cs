    public partial class Form1 : Form
    {
        Hex hex;
        public Form1()
        {
            InitializeComponent();
            hex = new Hex(this);
        }
    }
    class Hex
    {
        public Hex( Form1 frm)
        {
            frm.textBox2.AppendText("Hello World");
        }
    }
