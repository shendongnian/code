        public ActionResult NickName()
        {
            SqlConnection cn = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand(cmdStr, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string nickName = string.Empty;
            while (dr.Read())
            {
                nickName = dr["nick_Name"].ToString();
            }
            return Content(nickName);
        }
