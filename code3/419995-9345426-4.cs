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
        Form1 m;
        public Hex( Form1 frm)
        {
            m = frm;
            m.updateTextBox("Hello World");
        }
    }
