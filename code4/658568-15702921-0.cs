    public class spaceship
    {
        public spaceship(Form1 form)
        {
            myForm = form;
        }
        Form1 myform;
        public void mspaceship()
        {              
            myform.textBox1.Text = " working";               
        }
    }
    private void button4_Click(object sender, EventArgs e)
    {
        spaceship myspaceship = new spaceship(this);
        myspaceship.mspaceship();
    }
