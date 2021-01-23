    namespace autohide
    {
        public partial class Form1 : Form
        {
            public int pin = 0;
    
            public Form1()
            {
                InitializeComponent();
                panel1.Visible = false;
    
            }
            void ChangeIconPin()
            {
                switch (pin)
                {
                    case 0:
                        //Changes the pin-icon to display a unpinned frame.
                        this.button_Pin.BackgroundImage = autohidefixv2.Properties.Resources._55_roto;
                        break;
    
                    case 1:
                        //Changes the pin-icon to display a pinned frame.
                        this.button_Pin.BackgroundImage = autohidefixv2.Properties.Resources._55_2;
                        break;
    
                    default:
                        Console.WriteLine("sdasdad");
                        break;
                }
            }
    
    
            private void button1_MouseHover(object sender, EventArgs e)
            {
                panel1.Visible = true;
            }
    
            private void Form1_MouseEnter(object sender, EventArgs e)
            {
                if (pin == 0)
                {
                    panel1.Visible = false;
                }
                else
                {
                    return;
                }
            }
    
            private void button_Pin_Click(object sender, EventArgs e)
            {
                switch (pin)
                {
                    case 0:
                        pin = 1;
                        ChangeIconPin();
                        break;
                    case 1:
                        pin = 0;
                        ChangeIconPin();
                        break;
                    default:
                        Console.WriteLine("asdasda");
                        break;
                }
            }
        }
    }
