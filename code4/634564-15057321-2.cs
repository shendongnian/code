    public partial class Form1 : Form
    {
         public Form1()
         {
             InitializeComponent();
         }
       
         private void button1_Click(object sender, EventArgs e)
         {
             ChildForm first = new ChildForm();
             first.Number = 1;
             first.Show();
         }
    }
