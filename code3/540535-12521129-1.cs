    public class Form1 : Form
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed();
            Application.Exit();
        }
    }
    
