           protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		   {
			String Process = e.Row.Cells[0].Text;
			HyperLink link = new HyperLink();
			link.Text = Process;
			link.NavigateUrl = String.Format("~/IndexSummary.aspx?Process={0}&Machine={1}&Date={2}", Process, Request.QueryString["Machine"], Request.QueryString["Date"]);
			e.Row.Cells[0].Controls.Add(link);
			
		   }
