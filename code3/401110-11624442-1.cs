    using System.Windows.Forms;
    
    public class Form1 : Form
    {
        public Form1()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
    
            ReturnTextBox returntextbox = new ReturnTextBox();
            returntextbox.Text = "returntextbox";
            panel.Controls.Add(returntextbox);
    
            TextBox textBox1 = new TextBox();
            textBox1.Text = "Normal TextBox";
            panel.Controls.Add(textBox1);
    
            this.Controls.Add(panel);
        }
    }
    
    class ReturnTextBox : TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }
    
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.SelectedText = "    ";                
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }
