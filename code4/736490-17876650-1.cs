    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
            BindData();
       }
    }
    private void BindData()
    {
    }
    protected void AddNewCustomer(object sender, EventArgs e)
    {
             string CustomerID=((TextBox)GridView1.FooterRow.FindControl("txtCustomerID")).Text;
             string Name = ((TextBox)GridView1.FooterRow.FindControl("txtContactName")).Text;
             string Company = ((TextBox)GridView1.FooterRow.FindControl("txtCompany")).Text;
            //Your Code here...
     }
     protected void EditCustomer(object sender, GridViewEditEventArgs e)
     {
           GridView1.EditIndex = e.NewEditIndex;
            BindData();
     }
     protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
     {
          GridView1.EditIndex = -1;
          BindData();
      }
     protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
     {
          string CustomerID = ((Label)GridView1.Rows[e.RowIndex]
                        .FindControl("lblCustomerID")).Text;
          string Name = ((TextBox)GridView1.Rows[e.RowIndex]
                        .FindControl("txtContactName")).Text;
          string Company = ((TextBox)GridView1.Rows[e.RowIndex]
                        .FindControl("txtCompany")).Text;
          //Your code here...
      }
      protected void DeleteCustomer(object sender, EventArgs e)
      {
           LinkButton lnkRemove = (LinkButton)sender;
           SqlConnection con = new SqlConnection(strConnString);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "delete from  customers where " +
           "CustomerID=@CustomerID;" +
           "select CustomerID,ContactName,CompanyName from customers";
           cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value
        = lnkRemove.CommandArgument;
         GridView1.DataSource = GetData(cmd);
         GridView1.DataBind();
      }
