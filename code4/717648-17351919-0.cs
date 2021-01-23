            protected void Button1_Click(object sender, EventArgs e)
            {
    
                string RName = Page.Request.QueryString["RName"];
                string typeofquery = "mycommand";
                string pv1 = p1.Text;
                string pv2 = p2.Text;
                string abc = null;
                abc = "" + typeofquery + " @RName=" + RName + ",@P1='" + pv1 + "',@P2='" + pv2 + "'";
                SqlDataAdapter cmdldata = new SqlDataAdapter(abc, sqlconn);
    
                GridView1.PageSize = 1000;
    
    
                cmdldata.SelectCommand.CommandTimeout = 600;
    
                var dummyDt = new DataTable();
                dummyDt.Columns.Add("Sup");
                dummyDt.Columns.Add("Bro");
    
                dummyDt.Rows.Add("Test1", "test2");
                dummyDt.Rows.Add("Test1", "test2");
                dummyDt.Rows.Add("Test1", "test2");
                dummyDt.Rows.Add("Test1", "test2");
                dummyDt.Rows.Add("Test1", "test2");
    
                dsldata = new DataSet();
                dsldata.Tables.Add(dummyDt);
                //ErrorHandling errhandle = new ErrorHandling();
                try
                {
                    //cmdldata.Fill(dsldata);
                    Session["data"] = dsldata;
    
                    //DataView dataview_ldata = dsldata.Tables[0].DefaultView;
                    //DataTable dt = dsldata.Tables[0];
                    GridView1.DataSource = dsldata;
                    GridView1.DataBind();
    
                }//end of try
                catch (Exception ex)
                {
                    //String errorMessage = errhandle.displayException(ex);
                    Response.Write(ex.Message);
    
                }//end of catch
                finally
                {
                    //if (errhandle != null)
                    //{
                    //    errhandle = null;
                    //}
                }//end of finally
            }
            protected void Button2_Click(object sender, EventArgs e)
            {
                //DataSet ds0 = new DataSet();
                //ds0 = ;
                //DataView dataview_ldata = dsldata.Tables[0].DefaultView;
                //DataTable dt = dsldata.Tables[0];
                GridView1.DataSource = (DataSet)Session["data"];
                GridView1.DataBind();
                ExportToExcel(GridView1);
    
            }
    
            private void ExportToExcel(GridView GrdView)
            {
                try
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment; filename=FileName.xls");
                    Response.Charset = "";
                    // If you want the option to open the Excel file without saving than
                    // comment out the line below
                    // Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/vnd.xls";
                    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                    GrdView.RenderControl(htmlWrite);
                    Response.Write(stringWrite.ToString());
                    Response.End();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
