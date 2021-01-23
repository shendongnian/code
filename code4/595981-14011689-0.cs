        public IEnumerable<GW.Entities.user> GetAllUsers() {
            try {
                GWDataSet gw = new GWDataSet();
                List<GW.Entities.user> users = new List<user>();
                usersTableAdapter adapter = new usersTableAdapter();
                adapter.Fill(gw.users);
                foreach (GWDataSet.usersRow row in gw.users.Rows) {
                    users.Add(new GW.Entities.user {
                        UserId = row.IsNull("UserId") ? 0 : row.UserId,
                        UserName = row.IsNull("UserName") ? "" : row.UserName,
                        EmailAddress = row.IsNull("EmailAddress") ? "" : row.EmailAddress,
                        UserPasswordLastChange = row.IsNull("UserPasswordLastChange") ? DateTime.MinValue : row.UserPasswordLastChange,
                        LastLogin = row.IsNull("LastLogin") ? DateTime.MinValue : row.LastLogin,
                        StatusCd = row.IsNull("StatusCd") ? "" : row.StatusCd,
                        LastTimestamp = row.IsNull("LastTimestamp") ? null : row.LastTimestamp
                    });
                }
                return users;
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }
