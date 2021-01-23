    public class YourForm
    {
        private TextBox txtRun;
        private TextBox txtRun2;
        private void helloButton_Click(object sender, EventArgs e)
        {
            txtRun = new TextBox();
            txtRun2 = new TextBox();
            
            // removed less interesting initialization for readability
            
            this.Controls.Add(txtRun);
            this.Controls.Add(txtRun2);
        }
        public void DoStuffWithTextBoxes()
        {
            if (txtRun != null && txtRun2 != null)
            {
                // Retrieve text value and pass the values to another method
                SomeOtherMagicMethod(txtRun.Text, txtRun2.Text);
            }
        }
        private void SomeOtherMagicMethod(string txtRunText, string txtRun2Text)
        {
            // Do more magic
        }
    }
