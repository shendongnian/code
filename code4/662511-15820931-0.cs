    public partial class Form1 : Form
    {
       public Form1()
       {
           // Isn't there supposed to be InitializeComponent() here?
           // You should assign this in the designer, rather than here.
           label.Text = "Please push one of these buttons :";
       }
    
       private void buttonYes_Click(object sender, EventArgs e)
       {
           label.Text = "You just pushed YES button";
       }
       private void buttonNo_Click(object sender, EventArgs e)
       {
           label.Text = "You just pushed NO button";
       }
    }
