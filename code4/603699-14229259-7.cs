    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace Mvc4_Ajax.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
    
                return View();
            }
    
            public ActionResult About()
            {
                ViewBag.Message = "Your app description page.";
    
                return View();
            }
    
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";
    
                return View();
            }
            [HttpGet]
            public ActionResult SearchUser(string userName)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"].ToString());
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd = new SqlCommand("sp_UserName_Exist_tbl_UserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", userName);
                da.SelectCommand = cmd;
                da.Fill(dt);
                var isExisting = dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().ToLower() == "exists";
                return Json(new { IsExisting = isExisting }, JsonRequestBehavior.AllowGet);            
            }
        }
    }
