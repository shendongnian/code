    using System.Net.NetworkInformation;
    
        namespace PingTest1
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
                    Ping p = new Ping();
                    PingReply r;
                    string s;
                    s = textBox1.Text;
                    r = p.Send(s);
        
                    if (r.Status == IPStatus.Success)
                    {
                        lblResult.Text = "Ping to " + s.ToString() + "[" + r.Address.ToString() + "]" + " Successful"
                           + " Response delay = " + r.RoundtripTime.ToString() + " ms" + "\n";
                    }
                }
        
                private void textBox1_Validated(object sender, EventArgs e)
                {
                    if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text == "")
                    {
                        MessageBox.Show("Please use valid IP or web address!!");
                    }
                }
            }
        
        }
        
    
