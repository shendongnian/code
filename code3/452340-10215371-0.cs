    public partial class CustomerRibbon 
    { 
        private void butCustomAppointment_Click(object sender, RibbonControlEventArgs e) 
        { 
            try
            {
                frmBZAppointment frm = new frmBZAppointment(); 
                frm.Show(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        } 
    } 
