    public partial class Form1 : Form
    {
        public static List<string> lst=new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
              if (lst != null)
                listBox1.DataSource = lst;
        }
    }
    public partial class Form2 : Form
    {
           private void button1_Click(object sender, EventArgs e)
           {             
             Form1.lst.Add(textBox1.Text);
             textBox1.Text = string.Empty;
           }
     } 
