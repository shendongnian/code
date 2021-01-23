    public delegate void ColorEventHandler(object sender, ColorEventArgs e); 
    public partial class Form2 : Form
    {
        public event ColorEventHandler ColorEvent;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ColorEventArgs newColor = new ColorEventArgs();
            newColor.formColor=Color.Red;
            ColorEvent(this, newColor);
        }
       
    }
