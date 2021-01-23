    namespace WindowsFormsApplication1 
    {
      public partial class Form1 : Form
      {
         public Form1()
         {
             InitializeComponent();
         }
         private void button1_Click(object sender, EventArgs e)
         {
             listBox1.Items.Add(textBox1.Text);
             listBox1.Items.Add(textBox2.Text);
             listBox1.Items.Add(textBox3.Text);
             listBox1.Items.Add(textBox4.Text);
          }
      } 
    }
