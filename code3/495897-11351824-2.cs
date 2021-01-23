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
        using System.Configuration;
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
            DataSet dataSet = new DataSet();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISALog1ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("exec ProxyReport", conn);
            cmd.CommandTimeout = 200;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dataSet);
           GridView1.DataSource = dataSet.Tables[0];
           GridView1.DataBind();
           GridView2.DataSource = dataSet.Tables[1];
           GridView2.DataBind();
           GridView3.DataSource = dataSet.Tables[2];
           GridView3.DataBind();   
            dataSet.Tables[0].TableName = "1";
            dataSet.Tables[1].TableName = "2";
            dataSet.Tables[2].TableName = "3";
            int count = 3;   
                MemoryStream ms = GetExcel.DataTableToExcelXlsx(dataSet, count);
                ms.WriteTo(context.Response.OutputStream);
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                context.Response.AddHeader("Content-Disposition", "attachment;filename=EPPlusData.xlsx");
                context.Response.StatusCode = 200;
                context.Response.End();
            
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
