     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                listBox1.Items.AddRange(new[] { "AS","Ram"});           
            }
    
            protected override void OnLoad(EventArgs e)
            {
                listBox1.BeginInvoke(new Action(GetResult));
            }
    
            private void GetResult()
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(GetResult));
                }
                listBox1.SelectedIndex = 0;
            }
        }
