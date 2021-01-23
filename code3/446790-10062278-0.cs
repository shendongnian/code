    protected string _SessionName = null;
    public string SessionName
    {
        get
        {
            if (null == _SessionName)
            {
                using (var connection = new SqlConnection("connString"))
                {
                    connection.Open();
                    using (var command = new SqlCommand(" SELECT session_name FROM Sessions WHERE session_id = @SessionId", connection))
                    {
                        command.Parameters.Add("@SessionId", SqlDbType.Int);
                        command.Parameters["@SessionId"].Value = Convert.ToInt32(Request.QueryString["session"]);
    
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _SessionName = reader.GetString(0);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid session id");
                            }
                        }
                    }
                }
            }
            return _SessionName;
        }
        }
