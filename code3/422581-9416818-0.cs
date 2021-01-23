     public Form2()
    {
           CalculateValues myAdd = new CalculateValues();
           MulitplyValues Add = new MulitplyValues();
           InitializeComponent();
           button.Click += (o,e)=> {
                  int total = myadd.Add(int.Parse(textBox1.Text), int.Parse(textBox2.Text));    
                  MessageBox.Show(total.ToString());
           }
    }
