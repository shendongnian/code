    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public Color colTurn
            {
                get { return lblp1Turn.BackColor; }
                set { lblp1Turn.BackColor = value; }
            }
    
            public Label MyLabel
            {
                get {return mylabel1;}
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
        }
