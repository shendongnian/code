	//Read the Excel file in a byte array. here pck is the Excelworkbook              
	Byte[] fileBytes = pck.GetAsByteArray();
	//Clear the response               
	Response.Clear();
	Response.ClearContent();
	Response.ClearHeaders();
	Response.Cookies.Clear();
	//Add the header & other information      
	Response.Cache.SetCacheability(HttpCacheability.Private);
	Response.CacheControl = "private";
	Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
	Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
	Response.AppendHeader("Content-Length", fileBytes.Length.ToString());
	Response.AppendHeader("Pragma", "cache");
	Response.AppendHeader("Expires", "60");
	Response.AppendHeader("Content-Disposition",
	"attachment; " +
	"filename=\"ExcelReport.xlsx\"; " +
	"size=" + fileBytes.Length.ToString() + "; " +
	"creation-date=" + DateTime.Now.ToString("R") + "; " +
	"modification-date=" + DateTime.Now.ToString("R") + "; " +
	"read-date=" + DateTime.Now.ToString("R"));
	Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
	//Write it back to the client    
	Response.BinaryWrite(fileBytes);
	Response.End();
