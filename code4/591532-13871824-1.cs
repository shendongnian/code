    public partial class Form1 : Form
    {
        Button lastButton = null;
        int buttoncount;
        public Form1()
        {
            InitializeComponent();
            button1.Tag = "Ford Mustang";
            button2.Tag = "Ford Focus";
            button3.Tag = "Chevy Malibu";
            button4.Tag = "Chevy Camaro";
            button1.Click += button_Click;
            button2.Click += button_Click;
            button3.Click += button_Click;
            button4.Click += button_Click;
            //etc...
        }
        void button_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                SwitchTagWithText();
            }
            lastButton = sender as Button;
            SwitchTagWithText();
            buttoncount++;
            label2.Text = buttoncount.ToString();
        }
        void SwitchTagWithText()
        {
            string text = lastButton.Text;
            lastButton.Text = lastButton.Tag.ToString();
            lastButton.Tag = text;
        }
    }
