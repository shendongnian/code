    public partial class EditGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.MyDataList.Count == 0)
                {
                    this.populateData();
                }
                this.GridView1.DataSource = this.MyDataList;
                this.GridView1.DataBind();
            }
        }
        /// <summary>
        /// Data for the GridView. Encapsulates a list that will be in session.
        /// </summary>
        public IList<MyDataPoco> MyDataList
        {
            get
            {
                if (this.Session["MyDataList"] == null)
                    this.Session["MyDataList"] = new List<MyDataPoco>();
                return (IList<MyDataPoco>)this.Session["MyDataList"];
            }
        }
        /// <summary>
        /// Creates a list of 10 items.
        /// </summary>
        private void populateData()
        {
            for (int i = 0; i < 10; i++)
            {
                this.MyDataList.Add(
                    new MyDataPoco()
                    {
                        Id = i.ToString(),
                        Name = "Name " + i,
                        Phone = i + "" + i + "" + i + "." + i + "" + i + "" + i + "" + i + ""
                    });
            }
        }
        /// <summary>
        /// Here is the way you can get values from GridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.GridView1.SelectedRow;
            Label LblId = (Label)row.FindControl("LblId");
            Label LblName = (Label)row.FindControl("LblName");
            Label LblPhone = (Label)row.FindControl("LblPhone");
            this.TxtId.Text = LblId.Text;
            this.TxtName.Text = LblName.Text;
            this.TxtPhone.Text = LblPhone.Text;
        }
        /// <summary>
        /// Updates the data in the GridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.GridView1.SelectedIndex < 0)
            {
                this.ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "alert",
                    "alert('Select before...');", true);
            }
            else
            {
                MyDataPoco myDateItem = this.MyDataList[this.GridView1.SelectedIndex];
                myDateItem.Id = this.TxtId.Text;
                myDateItem.Name = this.TxtName.Text;
                myDateItem.Phone = this.TxtPhone.Text;
                this.GridView1.DataSource = this.MyDataList;
                this.GridView1.DataBind();
            }
        }
    }
    
