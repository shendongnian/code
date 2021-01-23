	namespace WebApplication1
	{
		using System;
		using System.Text;
		public partial class _Default : System.Web.UI.Page
		{
			protected void btnExport_Click(object sender, EventArgs e)
			{
				// Use UTF8 encoding
				Encoding csvEncoding = Encoding.UTF8;
				byte[] csvFile = TestByte(csvEncoding);
				string attachment = String.Format("attachment; filename={0}.csv", "docs_inv");
				Response.Clear();
				Response.ClearHeaders();
				Response.ClearContent();
				Response.ContentType = "text/csv";
				Response.ContentEncoding = csvEncoding;
				Response.AppendHeader("Content-Disposition", attachment);
				Response.BinaryWrite(csvFile);
				Response.Flush();
				Response.End();
			}
			public byte[] TestByte(Encoding encoding)
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat("Record1,Fred,Bloggs,26{0}", Environment.NewLine);
				sb.AppendFormat("Record2,John,Smith,32{0}", Environment.NewLine);
				return encoding.GetBytes(sb.ToString());
			}
		}
	}
