    public class YourForm
    {
        private TextBox txtRun;
        private TextBox txtRun2;
        private void helloButton_Click(object sender, EventArgs e)
        {
            txtRun = new TextBox();
            txtRun2 = new TextBox();
            txtRun2.Name = "txtDynamic2" + c++;
            txtRun.Name = "txtDynamic" + c++;
            txtRun.Location = new System.Drawing.Point(40, 50 + (20 * c));
            txtRun2.Location = new System.Drawing.Point(250, 50 + (20 * c));
            txtRun2.ReadOnly = true;
            txtRun.Size = new System.Drawing.Size(200, 25);
            txtRun2.Size = new System.Drawing.Size(200, 25);
            this.Controls.Add(txtRun);
            this.Controls.Add(txtRun2);
        }
        public void DoStuffWithTextBoxes()
        {
            if (txtRun != null && txtRun2 != null)
            {
                SomeOtherMagicMethod(txtRun.Text, txtRun2.Text);
            }
        }
        private void SomeOtherMagicMethod(string txtRunText, string txtRun2Text)
        {
            // Do more magic
        }
    }
