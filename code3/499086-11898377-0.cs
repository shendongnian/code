    public ActionResult Index()
        {
            UserRoleDAL udl = new UserRoleDAL();
            DataSet ds = udl.GetData(" SELECT USER_ROLE_ID, USERNAME, ROLE, ACTIVE_IND FROM LD_USER_ROLE");
            var ZUsers = new List<ZUserRoleModel>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var dr = ds.Tables[0].Rows[i];
                    
                    var ZUser = new ZUserRoleModel()
                    {
                        UserRoleId = Convert.ToInt64(dr["USER_ROLE_ID"]),
                        UserName = dr["USERNAME"].ToString(),
                        Role = dr["ROLE"].ToString(),
                        ActiveInd = ActiveBool
                    };
                    ZUsers.Add(ZUser);
                }
            }
            return View(ZUsers);
        }
