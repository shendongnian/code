    public class Form2 : Form
    {
       public event EventHandler UrlEntered;
       private void ButtonOK_Click(object sender, EventArgs e)
       {
           if (UrlEntered != null)
               UrlEntered(this, EventArgs.Empty);
       }
       public string Url { get { return urlTextBox.Text; } }
    }
