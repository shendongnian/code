    public partial class frmMyIP : Form
    {
        public frmMyIP()
        {
              InitializeComponent();
        }
        // To capture the Upper right "X" click
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x10) // The upper right "X" was clicked
            {
                AutoValidate = AutoValidate.Disable; //Deactivate all validations
            }
            base.WndProc(ref m);
        }
        // To capture the "Esc" key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                AutoValidate = AutoValidate.Disable;
                btnCancel.PerformClick(); 
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        public bool IsValidIP(string ipaddr)
        {
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])"+
            @"(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            Regex check = new Regex(pattern);
            bool valid = false;
            if (ipaddr == "")
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(ipaddr, 0);
            }
            return valid;
        }
        private void txtIPAddress_Validating(object sender, CancelEventArgs e)
        {
            string address = txtIPAddress.Text;
            if (!IsValidIP(address))
            {
                MessageBox.Show("Invalid IP address!");
                e.Cancel = true;
            }
        }
        private void cmbMaskBits_Validating(object sender, CancelEventArgs e)
        {
            int MaskBitsValue = Convert.ToInt32(cmbMaskBits.Text);
            
            if (MaskBitsValue<1 || MaskBitsValue>30)
            {
            MessageBox.Show("Please select a 'Mask Bits' value between 1 and 30!");
            e.Cancel = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Stop the validation of any controls so the form can close.
            // Note: The CausesValidation property of this <Cancel> button
            //       must also be set to false.
            
            AutoValidate = AutoValidate.Disable;
            this.Close();
        }
