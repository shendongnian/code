        if (!IsPostBack)
        {
          //Generate Data
          var data = new List<int>() { 76, -66, 646, -76, -10, -6, 16, 676 };
          gvGrid.DataSource = data;
          gvGrid.DataBind();
        }
      }
      protected void gvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
      {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          //Strongly Type Controls
          var litData = (Literal)e.Row.FindControl("litData");
          //Strongly Type Data
          var data = (int)e.Row.DataItem;
          //Display Data
          if (data < 0)
          {
            litData.Text = "[" + data.ToString() + "]";
          }
          else
          {
            litData.Text = data.ToString();
          }
        }
      }
