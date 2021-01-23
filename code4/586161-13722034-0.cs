    public partial class Form1 : Form
    {    
        static frmConfig f2 = new frmConfig();
        public Form1(frmConfig Cont)
        {
            f2 = Cont;
        }
        public String SIp;
    }
    ...
    private void btnNext_Click(object sender, EventArgs e)
    {
        if (cbSrc.SelectedItem != null && cbSrc.SelectedItem != "" && cbDest.SelectedItem != null && cbDest.SelectedItem != "")
        {
            this.Hide();
            //Form1 f1 = new Form1();
            f1.SIp = f2.txtSrcIP.text;
            f1.Show();
            this.Close();
        }
        else
        {
            MessageBox.Show("Enter all the details");
        }
    }
