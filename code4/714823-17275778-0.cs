            [WebMethod]
            public string[] Getlist(string keywordstartswith)
            {
                IList<string> output = new List<string>();
                Dictionary<string, string> mydict = new Dictionary<string, string>();
                string QueryString = System.Configuration.ConfigurationManager.ConnectionStrings["IUMSNXG"].ToString();
                IDataReader obj_result = SearchApp.DBCon.LRS_SP_CBFM_Sel(keywordstartswith).GetReader();
                DataTable dt = new DataTable();
                dt.Load(obj_result);
                if (dt.Rows.Count > 0)
                {
                    while (obj_result.Read())
                    {
                        output.Add(string.Format("{0}~{1}", obj_result["AnimalCode"].ToString().TrimEnd(), obj_result["pk_animalid"].ToString().TrimEnd()));
                    }
                }
                return output.ToArray();
            }
