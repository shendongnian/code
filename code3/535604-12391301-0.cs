        public partial class Form1 : Form
        {
            int _charIndex = 0;
            string _text = "Hello World!!";
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button_TypewriteText_Click(object sender, EventArgs e)
            {
                _charIndex = 0;
                label1.Text = string.Empty;
                Thread t = new Thread(new ThreadStart(this.TypewriteText));
                t.Start();
            }
    
            private void TypewriteText()
            {
                while (_charIndex < _text.Length)
                {
                    Thread.Sleep(500);
                    label1.Invoke(new Action(() =>
                    {
                        label1.Text += _text[_charIndex];
                    }));
                    _charIndex++;
                }
            }
        }
