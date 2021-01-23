    protected void grdvEventosVendedor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType = DataControlRowType.DataRow)
      {
          if(put_your_condition_here)
          {
               e.Row.BackColor = Drawing.Color.Red;
          }
      }
    }
