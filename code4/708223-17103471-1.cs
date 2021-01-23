            [HttpGet]
        // Get api/wmssettings/excel 
        public HttpResponseMessage Excel(string sidx, string sord, int page, int rows, string Depot, string PDID, string User, string Property, string Value)
        {
            if (AuthHelper.AuthService.HasValidCredentials(Request))
            {
                var gridResult = this.GetDataJqGridFormat(sidx, sord, page, rows, Depot, PDID, User, Property, Value);
                // Generate a HTML table.
                StringBuilder builder = new StringBuilder();
                // We create a html table:
                builder.Append("<table border=1>");
                builder.Append("<tr><td>DEPOT</td>");
                builder.Append("<td>PDID</td>");
                builder.Append("<td>USER</td>");
                builder.Append("<td>PROPERTY</td>");
                builder.Append("<td>VALUE</td></tr>");
                // Create response from anonymous type            
                foreach (var item in gridResult.rows)
                {
                    builder.Append("</tr>");
                    builder.Append("<tr>");
                    builder.Append("<td>" + item.cell[0] + "</td>");
                    builder.Append("<td>" + item.cell[2] + "</td>");
                    builder.Append("<td>" + item.cell[3] + "</td>");
                    builder.Append("<td>" + item.cell[4] + "</td>");
                    builder.Append("<td>" + item.cell[5] + "</td>");
                }
                builder.Append("</table>");
                // Put all in a file and return the url:
                string fileName = "export" + "_" + Guid.NewGuid().ToString() + ".xls";
                using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("~/Downloads" + fileName)))
                {
                    writer.Write(builder.ToString());
                    writer.Flush();                    
                }
                HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, fileName);
                return result;
            }
            else
            {
                throw ForbiddenResponseMessage();
            }
        }
