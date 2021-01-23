    public partial class FilterGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void BtnQuery_Click(object sender, EventArgs e)
        {
            //change this values causes the 'OdsMyData' 'DataBind'.
            this.HdfId.Value = this.TxtId.Text;
            this.HdfName.Value = this.TxtName.Text;
            this.HdfPhone.Value = this.TxtPhone.Text;
            this.HdfDoQuery.Value = true.ToString();
        }
    }
