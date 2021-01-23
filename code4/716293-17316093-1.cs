    public class Form1: Form
    {
        public Form1()
        {
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }
    
        public void click()
        {
            textBox1.Text = "asdasdas";
        }
    
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }    
    }
