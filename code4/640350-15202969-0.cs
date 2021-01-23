    public partial class frmManager : Form
    {
        public String Name
        {
            get 
            {
                return txtName.Text;
            }
            set;  // you may also want to change this to set the value of txtName.Text (txtName.Text = value)
        }
    }
