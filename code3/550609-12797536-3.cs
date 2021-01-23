    public partial class form3 : Form
    {
        public String SomeName
        {
            get
            {
                return textbox1.Text;
            }
        }
        
        ...
        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
     }
