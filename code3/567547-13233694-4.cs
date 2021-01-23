    public partial class Form1 : Form
        {
            private myCounter _counterClass;
            public Form1()
            {
                InitializeComponent();
            }
    
            public Label MyLabel1
            {
                get {return mylabel1;}
            }
            public Label MyLabel2
            {
                get {return mylabel2;}
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _counterClass = new myCounter(this);
            }
            protected void ButtonClick(object sender, EventArgs e)
            {
                _counterClass.changeColor();
            }
        }
