    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtSODate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            //--
            dtProductDet = new DataTable("dtProductDet");
            dtProductDet.Columns.Add("PID", typeof(int));
            dtProductDet.Columns.Add("PName", typeof(string));
            dtProductDet.Columns.Add("Quan", typeof(decimal));
            dtProductDet.Rows.Add(0,"",0);
            //--
            SetGridViewSource();
        }
        else
        {
            DataTable dtPD = dtProductDet;
            DropDownList ddlProd = null;
            if (GridView1.Rows.Count > 0)
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    ddlProd = (DropDownList)GridView1.Rows[i].Cells[gvci_Prod].FindControl("ddlProduct");
                    dtPD.Rows[i]["PID"] = Convert.ToInt32(ddlProd.SelectedItem.Value);
                    dtPD.Rows[i]["PName"] = ddlProd.SelectedItem.Text;
                    dtPD.Rows[i]["QUAN"] = ((TextBox)GridView1.Rows[i].Cells[gvci_Quan].FindControl("txtQuan")).Text;
                }
            }
            dtProductDet = dtPD;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dtProductDet.Rows.Add(0, "", 0);
        DataTable dtPDet = dtProductDet;
        GridView1.DataSource = dtPDet;
        GridView1.DataBind();
        DropDownList ddlProd = null;
        DataRow drFind = null;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            ddlProd = (DropDownList)GridView1.Rows[i].Cells[gvci_Prod].FindControl("ddlProduct");
            drFind = dtProductMaster.Rows.Find(dtPDet.Rows[i]["PID"]);
            if(drFind != null)
            {
                ddlProd.SelectedIndex = dtProductMaster.Rows.IndexOf(drFind);
            }
        }
    }
