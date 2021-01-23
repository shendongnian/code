    public class Form2 : System.Windows.Forms.Form
    {
        // Define delegate
        public delegate void PassControl(object sender);
     
        // Create instance (null)
        public PassControl passControl;
     
        private void btnForm2_Click(object sender, System.EventArgs e)
        {
            if (passControl != null)
            {
                passControl(txtForm2);
            {
            this.Hide();
        }
    }
