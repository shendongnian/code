    protected void grdvEventosVendedor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType = DataControlRowType.DataRow)
      {
          if(put_your_condition_here)
          {
               e.Row.BackColor = Drawing.Color.Red;
               //// or you can assign color by doing this: e.Row.BackColor = Color.FromName("#FFOOOO");
          }
      }
    }
