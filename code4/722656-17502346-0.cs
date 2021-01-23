    namespace test2
    {
        public partial class Form1 : Form
        {
            public delegate void button_click(object sender, EventArgs e);
            public static button_click[] clickMethods = new button_click[4];
            public Form1()
            {
                InitializeComponent();
            }
            public class LEDButton : Button
            {
                public const int LEDWidth = 50;
                public const int LEDHeight = 30;
                public LEDButton()
                {
                    BackColor = Color.Tan;//inner color
                    //BackColor = Color.FromArgb(0, 64, 0);
                    ForeColor = Color.Yellow;//outline
                    FlatStyle = FlatStyle.Popup;//Button style
                    Size = new Size(LEDWidth, LEDHeight);
                    UseVisualStyleBackColor = false;
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                clickMethods[0] = buttonGeneric_Click_1;
                clickMethods[1] = buttonGeneric_Click_2;
                clickMethods[2] = buttonGeneric_Click_3;
                clickMethods[3] = buttonGeneric_Click_4;
            }
            private void buttonGeneric_Click_1(object sender, EventArgs e)
            {
    
            }
            private void buttonGeneric_Click_2(object sender, EventArgs e)
            {
    
            }
            private void buttonGeneric_Click_3(object sender, EventArgs e)
            {
    
            }
            private void buttonGeneric_Click_4(object sender, EventArgs e)
            {
    
            }
            private void button1_Click_1(object sender, EventArgs e)
            {
                LEDButton[,] b = new LEDButton[4, 4];
                for (int y = 0; y < b.GetUpperBound(0); y++)
                {
                    for (int x = 0; x < b.GetUpperBound(1); x++)
                    {
                        b[y, x] = new LEDButton()
                        {
                            //put button properties here
                            Name = "button" + y.ToString() + x.ToString(),//String.Format("Button{0}{1}", y, x),
                            TabIndex = 10 * y + x,
                            Text = y.ToString() + x.ToString(),
                            Location = new Point(LEDButton.LEDWidth * x + 20, LEDButton.LEDHeight * y + 20)
                        };
    
                        if (y <= 3)
                        {
                            b[y, x].Click += new System.EventHandler(clickMethods[y]); 
                        }
                    }
                }
                // add buttons to controls
                for (int y = 0; y < b.GetUpperBound(0); y++)
                    for (int x = 0; x < b.GetUpperBound(1); x++)
                        this.Controls.Add(b[y, x]);
            }
        }
    }
