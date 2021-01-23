    public partial class Form3 : Form
    {
        public Form1 f1 { get;set;}
        public Form2 f2 { get;set;}
        ...
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(f1 != null)
                f1.Show();
        }
    }
