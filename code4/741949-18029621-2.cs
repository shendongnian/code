    public class MyForm : Form
    {
        protected virtual void OnFormClosing(FormClosingEventArgs e)
        {
            // Prevent the form from closing.
            e.Cancel = true;
            // Hide it instead.
            this.Hide();
        }
        
        // ...other code in your form class
    }    
