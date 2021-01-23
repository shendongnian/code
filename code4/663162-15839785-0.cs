        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindFormView();
			}
		}
		private void BindFormView()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("coffeeName", typeof(string));
			dt.Columns.Add("coffeeOrigin", typeof(string));
			dt.Columns.Add("coffeeStrength", typeof(int));
			dt.Columns.Add("coffeePrice", typeof(double));
			dt.Columns.Add("coffeeGrind", typeof(string));
			dt.Columns.Add("coffeeQty", typeof(int));
			dt.Columns.Add("coffeeRRP", typeof(int));
			DataRow dr = dt.NewRow();
			dr["coffeeName"] = "Kenya";
			dr["coffeeOrigin"] = "Smooth";
			dr["coffeeStrength"] = 6;
			dr["coffeePrice"] = 2.99;
			dr["coffeeGrind"] = "Kenya";
			dr["coffeeQty"] = 6;
			dt.Rows.Add(dr);
			FormView1.DataSource = dt;
			FormView1.DataBind();
		}
		protected void btnHideRow_Click(object sender, EventArgs e)
		{
			Session["HideRow"] = Session["HideRow"] == null ? false :                                        (bool)Session["HideRow"];
			BindFormView();
		}
		protected void FormView1_DataBound(object sender, EventArgs e)
		{
			if (Session["HideRow"] != null)
			{
				var pnlToHide = FormView1.FindControl("panelLevel");
				pnlToHide.Visible = (bool)Session["HideRow"];
			}
		}
