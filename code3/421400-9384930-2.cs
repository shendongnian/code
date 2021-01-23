        public int usp_DoSomethingWithTableTypedParameter(List<UserID> userIdList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(int));
            foreach (var userId in updateList)
            {
                dt.Rows.Add(new object[] { userId });
            }
            int rowsAffected = ExecStoredProcWithTVP(Connection, "usp_DoSomethingWithTableTypedParameter", "@UserIdList", "udt_UserId", dt);
            return rowsAffected;
        }
