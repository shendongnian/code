                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
                    Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");
                    //sets font
                    Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
                    Response.Write("<br/><br/><br/>");
    Response.Write("<table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-family:Calibri; background:white;'>");
        ...More output data ...            // Send to save
                    Response.Write("</table>");
                    Response.Flush();
                    Response.End();
