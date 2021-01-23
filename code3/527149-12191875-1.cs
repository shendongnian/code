    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
          gvBind();
       }
     }
    
     public void gvBind()
      {
         DataTable dt = createTable();
         Session["tb"] = dt;
         gvshipping.DataSource = Session["tb"];
         gvshipping.DataBind();
      }
    
      protected void gvshipping_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList dpshipmethod = (DropDownList)e.Row.FindControl("DropDownList1");
                    //bind dropdownlist
                    DataTable dt = shipingmethodTable();
                    dpshipmethod.DataSource = dt;
                    dpshipmethod.DataTextField = "ShippingMethod";
                    dpshipmethod.DataValueField = "Id";
                    dpshipmethod.DataBind();
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    dpshipmethod.SelectedItem.Text = dr["ShippingMethod"].ToString();
                
                }
            }
        }
    
     protected void gvshipping_RowEditing(object sender, GridViewEditEventArgs e)
    {
          gvshipping.EditIndex = e.NewEditIndex;
          vBind();
     }
    
     protected void gvshipping_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
     {
       gvshipping.EditIndex = -1;
        gvBind();
     }
    
    
        public DataTable createTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Part", typeof(string));
            dt.Columns.Add("Quantity", typeof(Int32));
            dt.Columns.Add("ShipTo", typeof(string));
            dt.Columns.Add("RequestedDate", typeof(string));
            dt.Columns.Add("ShippingMethod", typeof(string));
           
            string date= DateTime.Now.ToShortDateString();
            DataRow row = dt.NewRow();
            row["Part"] = "Anchor";
            row["Quantity"] = "10";
            row["ShipTo"] = "blah";
            row["RequestedDate"] = date;
            row["ShippingMethod"] = "Charge by subtotal";
            dt.Rows.Add(row);
    
           
            DataRow row1 = dt.NewRow();
            row1["Part"] = "blade";
            row1["Quantity"] = "88";
            row1["ShipTo"] = "blah";
            row1["RequestedDate"] = date;
            row1["ShippingMethod"] = "Charge by quantity";
            dt.Rows.Add(row1);
    
            DataRow row2 = dt.NewRow();
            row2["Part"] = "cabin";
            row2["Quantity"] = "4";
            row2["ShipTo"] = "blah";
            row2["RequestedDate"] = date;
            row2["ShippingMethod"] = "Charge by subtotal";
            dt.Rows.Add(row2);
    
            DataRow row3 = dt.NewRow();
            row3["Part"] = "cockpit";
            row3["Quantity"] = "11";
            row3["ShipTo"] = "blah";
            row3["RequestedDate"] = date;
            row3["ShippingMethod"] = "Charge by weight";
            dt.Rows.Add(row3);
    
            DataRow row4 = dt.NewRow();
            row4["Part"] = "jack";
            row4["Quantity"] = "45";
            row4["ShipTo"] = "blah";
            row4["RequestedDate"] = date;
            row4["ShippingMethod"] = "Charge by weight";
            dt.Rows.Add(row4);
    
            DataRow row5 = dt.NewRow();
            row5["Part"] = "cabin";
            row5["Quantity"] = "67";
            row5["ShipTo"] = "blah";
            row5["RequestedDate"] = date;
            row5["ShippingMethod"] = "Charge by weight";
            dt.Rows.Add(row5);
    
            DataRow row6 = dt.NewRow();
            row6["Part"] = "blade";
            row6["Quantity"] = "4";
            row6["ShipTo"] = "blah";
            row6["RequestedDate"] = date;
            row6["ShippingMethod"] = "Charge by weight";
            dt.Rows.Add(row6);
            return dt;
        }
    
        public DataTable shipingmethodTable()
        {
            DataTable dtshipingmethod = new DataTable();
            dtshipingmethod.Columns.Add("Id", typeof(Int32));
            dtshipingmethod.Columns.Add("ShippingMethod", typeof(string));
    
            DataRow row = dtshipingmethod.NewRow();
            row["Id"] = 1;
            row["ShippingMethod"] = "Charge by subtotal";
            dtshipingmethod.Rows.Add(row);
    
            DataRow row1 = dtshipingmethod.NewRow();
            row1["Id"] = 2;
            row1["ShippingMethod"] = "Charge by weight";
            dtshipingmethod.Rows.Add(row1);
    
            DataRow row2 = dtshipingmethod.NewRow();
            row2["Id"] = 3;
            row2["ShippingMethod"] = "Charge by quantity";
            dtshipingmethod.Rows.Add(row2);
    
            return dtshipingmethod;
    
        }
