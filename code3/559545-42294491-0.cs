    <%@ WebHandler Language="C#" Class="CountryStateCityHandler" %>
    
    using System;
    using System.Web;
    using System.Data;
    using System.Collections.Generic;
    
    public class CountryStateCityHandler : IHttpHandler
    {
    public void ProcessRequest(HttpContext context)
    {
    if (context.Request.QueryString["action"] != null)
    {
    string strCallbackFunf = string.Empty;
    
    if (context.Request.QueryString["callback"] != null)
    {
    strCallbackFunf = Convert.ToString(context.Request.QueryString["callback"]).Trim();
    }
    
    if (context.Request.QueryString["action"] == "getcountry")
    {                   
    DataTable dt = GetDataTable("EXEC PR_GetCountries"); //GetDataTable need to write, this method will call the Database and get the result
    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
    Dictionary<string, object> row;
    foreach (DataRow dr in dt.Rows)
    {
    row = new Dictionary<string, object>();
    foreach (DataColumn col in dt.Columns)
    {
    row.Add(col.ColumnName, dr[col]);
    }
    rows.Add(row);
    }
    
    context.Response.ContentType = "text/plain";
    if (string.IsNullOrEmpty(strCallbackFunf))
    {
    context.Response.Write(serializer.Serialize(rows));
    }
    else
    {
    context.Response.Write(strCallbackFunf+"("+serializer.Serialize(rows)+");");      
    }
    }
    }
    }
    public bool IsReusable
    {
    get
    {
    return false;
    }
    }
    }
