    using EmployeeTrackingSystemAndMIS.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Mvc;
    namespace EmployeeTrackingSystemAndMIS.Controllers
    {
        public class ClientController : Controller
        {
            private EmployeeTrackingSystemAndMISEntities db = new EmployeeTrackingSystemAndMISEntities();
            public string SearchMis()
            {
                string limit, start, searchKey, orderColumn, orderDir, draw, jsonString;
                limit = Request.QueryString["length"] == null ? "" : Request.QueryString["length"].ToString();
                start = Request.QueryString["start"] == null ? "" : Request.QueryString["start"].ToString();
                searchKey = Request.QueryString["search[value]"] == null ? "" : Request.QueryString["search[value]"].ToString();
                orderColumn = Request.QueryString["order[0][column]"] == null ? "" : Request.QueryString["order[0][column]"].ToString();
                orderDir = Request.QueryString["order[0][dir]"] == null ? "" : Request.QueryString["order[0][dir]"].ToString();
                draw = Request.QueryString["draw"] == null ? "" : Request.QueryString["draw"].ToString();
                var parameter = new List<object>();
                var param = new SqlParameter("@orderColumn", orderColumn);
                parameter.Add(param);
                param = new SqlParameter("@limit", limit);
                parameter.Add(param);
                param = new SqlParameter("@orderDir", orderDir);
                parameter.Add(param);
                param = new SqlParameter("@start", start);
                parameter.Add(param);
                param = new SqlParameter("@searchKey", searchKey);
                parameter.Add(param);
                        
                var CompanySearchList = db.Database.SqlQuery<CompanySearch>("EXEC SearchCompany @orderColumn,@limit,@orderDir,@start,@searchKey ", parameter.ToArray()).ToList();
            
                dynamic newtonresult = new
                {
                    status = "success",
                    draw = Convert.ToInt32(draw == "" ? "0" : draw),
                    recordsTotal = CompanySearchList.FirstOrDefault().TotalCount,
                    recordsFiltered = CompanySearchList.FirstOrDefault().TotalCount,
                    data = CompanySearchList
                };
                jsonString = JsonConvert.SerializeObject(newtonresult);
                return jsonString;
            }
            private class CompanySearch
            {
                public int TotalCount { get; set; }
                public string abc { get; set; }
                public string Address { get; set; }
                public int? ClientID { get; set; }
                public int? EmployeeID { get; set; }
                public string name { get; set; }
                public int CompanyID { get; set; }
            }
        }
    }
