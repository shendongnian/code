    public void CreateExcel(GridView dgDetails, string fileName)
              {
                  dgDetails.AllowPaging = false;
                  dgDetails.DataBind();
                  Response.ClearContent();
                  Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ""+fileName+".xls"));
                  Response.Charset = "";
                  Response.ContentType = "application/ms-excel";
                  StringWriter sw = new StringWriter();
                  HtmlTextWriter htw = new HtmlTextWriter(sw);
                  dgDetails.RenderControl(htw);
                  Response.End();         
              }
