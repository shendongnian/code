     public partial class Add_Order : Form
        {
            public Add_Order()
            {
                InitializeComponent();
            }
    
            public Info Get_Data()
            {
                return new Info() { _textBox3 = textBox3.Text,
                                    _label6 = label6.Text,
                                    _textBox2 = textBox2.Text,
                                    _textBox1 = textBox1.Text,
                };
            }
    
        }
        struct Info
        {
            public string _textBox3;
            public string _label6;
            public string _textBox2;
            public string _textBox1;
        }
