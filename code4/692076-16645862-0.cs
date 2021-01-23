    //---------------My c# Code Behind file--------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI.HtmlControls;
    public partial class _Default : System.Web.UI.Page
    {
    protected void Page_init(object sender, EventArgs e)
    {
    GenerateDataGrids();
    if (!Page.IsPostBack)
    { }
    }
    public void GenerateDataGrids()
    {
    //-- Instantiate the data set and table
    DataSet ds = new DataSet();
    DataTable dt = ds.Tables.Add();
    //-- Add columns to the data table
    dt.Columns.Add("ID", typeof(int));
    dt.Columns.Add("Book", typeof(string));
    dt.Columns.Add("Author", typeof(string));
    //-- Add rows to the data table
    dt.Rows.Add(1, "1984", "George Orwell");
    dt.Rows.Add(2, "Notes from the Underground", "Fydor Dostoyevsky");
    dt.Rows.Add(3, "The Outsider", "Albert Camus");
    dt.Rows.Add(4, "Post Office", "Charles Buchowski");
    dt.Rows.Add(5, "The Chant of Maldoror", "Comte De Lautremont");
    DataGrid dg = new DataGrid();
    dg.ID = ID;
    dg.DataSource = ds;
    dg.AutoGenerateColumns = false;
    DataTable Workdt = new DataTable();
    Workdt = ds.Tables[0];
    for (int i = 0; i <= dt.Columns.Count - 1; i++)
    {
    // Creating Template Column
    TemplateColumn tc = new TemplateColumn();
    string columnName = dt.Columns[i].ColumnName;
    tc.HeaderTemplate = new DataGridTemplate(ListItemType.Header, columnName);
    for (int j = 1; j <= dt.Rows.Count - 1; j++)
    {
    string RowCallName = dt.Rows[j][i].ToString();
    tc.ItemTemplate = new DataGridTemplate(ListItemType.EditItem, RowCallName);
    }
    dg.Columns.Add(tc);
    }
    dg.DataBind();
    form1.Controls.Add(dg);
    }
    }
    public class DataGridTemplate : ITemplate
    {
    ListItemType templateType;
    string columnName;
    public DataGridTemplate(ListItemType type, string colname)
    {
    templateType = type;
    columnName = colname;
    }
    public void InstantiateIn(System.Web.UI.Control container)
    {
    Literal lc = new Literal();
    switch (templateType)
    {
    case ListItemType.Header:
    lc.Text = "<B>" + columnName + "</B>";
    container.Controls.Add(lc);
    break;
    case ListItemType.Item:
    lc.Text = "Item " + columnName;
    container.Controls.Add(lc);
    break;
    case ListItemType.EditItem:
    TextBox tb = new TextBox();
    tb.Text = columnName;
    container.Controls.Add(tb);
    break;
    case ListItemType.Footer:
    lc.Text = "<I>" + columnName + "</I>";
    container.Controls.Add(lc);
    break;
    }
    }
    }
    
    <%----------------The ASP.NET File-------------------------%>
    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="_Default" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title></title>
    </head>
    <body>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
    </body>
    </html>
