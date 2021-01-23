	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Data;
	using System.Configuration;
	using AppBlock;
	using System.Data.SqlClient;
	using Newtonsoft.Json;
	namespace alfest.Ajax
	{
	  public partial class Category : System.Web.UI.Page
	  {
		string mode, option, user, limit, start, searchKey, orderByColumn, orderByDir, estMstSrno, pnlsrno, draw, jsonString;
		CommonClass cmnCls = new CommonClass();
		protected void Page_Load(object sender, EventArgs e)
		{
		  mode = Request.QueryString["mode"] == null ? "" : Request.QueryString["mode"].ToString();
		  option = Request.QueryString["option"] == null ? "" : Request.QueryString["option"].ToString();
		  limit = Request.QueryString["length"] == null ? "" : Request.QueryString["length"].ToString();
		  start = Request.QueryString["start"] == null ? "" : Request.QueryString["start"].ToString();
		  user = Request.QueryString["user"] == null ? "" : Request.QueryString["user"].ToString();
		  searchKey = Request.QueryString["search[value]"] == null ? "" : Request.QueryString["search[value]"].ToString();
		  orderByColumn = Request.QueryString["order[0][column]"] == null ? "" : Request.QueryString["order[0][column]"].ToString();
		  orderByDir = Request.QueryString["order[0][dir]"] == null ? "" : Request.QueryString["order[0][dir]"].ToString();
		  estMstSrno = Request.QueryString["estMstSrno"] == null ? "" : Request.QueryString["estMstSrno"].ToString();
		  pnlsrno = Request.QueryString["pnlsrno"] == null ? "" : Request.QueryString["pnlsrno"].ToString();
		  draw = Request.QueryString["draw"] == null ? "" : Request.QueryString["draw"].ToString();
		
			
		   // Cls_Category CatgObj = new Cls_Category();
		   // CatgObj.orderColumn = Convert.ToInt32(orderByColumn);
		   // CatgObj.limit = Convert.ToInt32(limit);
		   // CatgObj.orderDir = orderByDir;
		   // CatgObj.start = Convert.ToInt32(start);
		   // CatgObj.searchKey = searchKey;
		   // CatgObj.option = "GetAllAdminCategory";
		  // or user your own method to get data (just fill the dataset)
		  
		  //  DataSet ds = cmnCls.PRC_category(CatgObj);
			dynamic newtonresult = new
			  {
				status = "success",
				draw = Convert.ToInt32(draw == "" ? "0" : draw),
				recordsTotal = ds.Tables[1].Rows[0][0],
				recordsFiltered = ds.Tables[1].Rows[0][0],
				data = ds.Tables[0]
			  };
			jsonString = JsonConvert.SerializeObject(newtonresult);
			Response.Clear();
			Response.ContentType = "application/json";
			Response.Write(jsonString);
		 
		}
	  }
	}
