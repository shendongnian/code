    public partial class Form1
    {
        public void Main()
        {
        bool authenticated = ...
    
        if(!authenticated)
        {
           Your_Form newForm = new Your_Form();
           newForm.Show(this);
           string password = newForm.Password;
           if(password != "")
               ...
        }
        }
        }
    
    public class Your_Form
    {
    public TextBox textBox1 = new Textbox();
    ...
    public string Password = "";
    
    private void button1_Click(object sender, EventArgs e)
    {
       this.Password = textBox1.Text;
    }
    ...
    }
