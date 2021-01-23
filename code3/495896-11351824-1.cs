        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Data;
        using System.Data.SqlClient;
        using System.IO;
        using OfficeOpenXml;
        public partial class _Default : System.Web.UI.Page
     {
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetExcel ge = new GetExcel();
        ge.ProcessRequest(HttpContext.Current);
    }
    public class GetExcel : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE; Integrated Security=true;";
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                c.Open();
                DataSet ds = new DataSet("ds");
                DataTable dt1 = ds.Tables.Add("1");
                DataTable dt2 = ds.Tables.Add("2");
                DataTable dt3 = ds.Tables.Add("3");
                int count = 3;
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.CommandText = "StoredProcedureName1";   
                reader = cmd.ExecuteReader();
                dt1.Load(reader);
                cmd.CommandText = "StoredProcedureName2";
                reader = cmd.ExecuteReader();
                dt2.Load(reader);
                cmd.CommandText = "StoredProcedureName3";
                reader = cmd.ExecuteReader();
                dt3.Load(reader);
                MemoryStream ms = GetExcel.DataTableToExcelXlsx(ds, count);
                ms.WriteTo(context.Response.OutputStream);
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                context.Response.AddHeader("Content-Disposition", "attachment;filename=EasyEditCmsGridData.xlsx");
                context.Response.StatusCode = 200;
                context.Response.End();
                c.Close();
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public static MemoryStream DataTableToExcelXlsx(DataSet ds, int count)
        {
            MemoryStream Result = new MemoryStream();
            ExcelPackage pack = new ExcelPackage();
            for (int i = 1; i <= count; i++)
            {
                DataTable table = ds.Tables[i.ToString()];
                ExcelWorksheet ws = pack.Workbook.Worksheets.Add("MySheet" + i.ToString());
                int col = 1;
                int row = 1;
                foreach (DataColumn cl in table.Columns)
                {
                    ws.Cells[row, col].Value = cl.ColumnName;
                    col++;
                }
                col = 1;
                foreach (DataRow rw in table.Rows)
                {
                    foreach (DataColumn cl in table.Columns)
                    {
                        if (rw[cl.ColumnName] != DBNull.Value)
                            ws.Cells[row + 1, col].Value = rw[cl.ColumnName].ToString();
                        col++;
                    }
                    row++;
                    col = 1;
                }
            }
            pack.SaveAs(Result);
            return Result;
        }
    }}
