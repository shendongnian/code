            protected void          grdvResults_RowDataBound(object sender, GridViewRowEventArgs e)
            {
               if (e.Row.DataItem != null)
               {
                   ((LinkButton)e.Item.FindControl("lnkname")).PostBackUrl = "~/somewhere/" + Session["path"].ToString();
               }
            }
