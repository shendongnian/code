    [WebMethod(Description = "Add or Amend Availability & Rates")]
            public bool Avail(string Username, string Password, DateTime Dte, DateTime Dtm, int ID, string RoomType, int Qty, double CurPrice)
            {
                GetCredentials(Username, Password);
                int ID= Convert.ToInt16(GetCredentials(Username, Password).Tables[0].Rows[0]["strTypeID"]);
                bool retVal = false;
                GetCredentials(Username, Password);
                List<DataTime> existingDates = new List<DataTime>(); //AJAY:- This is to keep a track of what is already in the DataBase
                using (SqlConnection mySQLconnection = new SqlConnection(connStr))
                {
                    //AJAY:- Get the data for the whole Range from the DataBase
                    using (SqlCommand dbCommand = new SqlCommand("select * from Available where intID=@ID and dtm BETWEEN @Dte AND @Dtm and strRoomType=@RoomType", mySQLconnection))
                    {
                        SqlParameter dtStart = new SqlParameter("@Dte", Dte);
                        SqlParameter dtEnd = new SqlParameter("@Dtm", Dtm);
                        SqlParameter RoomT = new SqlParameter("@RoomType", RoomType);
                        SqlParameter typeI = new SqlParameter("@ID", ID);
                        dbCommand.Parameters.Add(dtStart);
                        dbCommand.Parameters.Add(dtEnd);
                        dbCommand.Parameters.Add(RoomT);
                        dbCommand.Parameters.Add(typeI);
                        mySQLconnection.Open();
                        using (SqlDataReader reader = dbCommand.ExecuteReader())
                        {
                            
                            while(reader.read())
                            {
                                existingDates.Add(Convert.ToDateTime((string)reader["Dtm"])); //AJAY:- Change it as per your format of Dtm column in table schema
                            }
    
                            for (DateTime date = Dte; date <= dat; date = date.AddDays(1.0))
                            {
                                if(existingDates.Contains(date)) //AJAY:- record is already there just update it
                                {
                                    AmdAvail(Username, Password, date, RoomType, Qty, CurPrice);
                                }
                                else //AJAY:- Record is not present ADD it
                                {
                                    AddAvail(Username, Password, date, RoomType, Qty, CurPrice);
                                }        
                            }
                            mySQLconnection.Close();
                            dbCommand.Dispose();
                            mySQLconnection.Dispose();
                            return retVal;
                        }            
                    }
                }
            }
    
     /*----------------------------------------------------
         * //AJAY:- Webmethod AddAvail Adds single availability for a speicifed date
         * ---------------------------------------------------*/
        [WebMethod(Description = "Single Add of Availability", BufferResponse = true)]
        public void AddAvail(string Username, string Password, DateTime date, string RoomType, int Qty, double CurPrice)
        {
            GetAuthCredentials(Username, Password);
            DateTime dat = Dtm;
            int strTypeID = Convert.ToInt16(GetAuthCredentials(Username, Password).Tables[0].Rows[0]["strTypeID"]);
            using (SqlConnection mySQLconnection = new SqlConnection(connStr))
            {
                mySQLconnection.Open();
                string sqlInsertString = "INSERT INTO Available (dtm,intResortID,strRoomType,intQty,curPrice) VALUES (@dat,@strTypeID,@strRoomType,@intQty,@CurPrice)";
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = mySQLconnection;
                    command.CommandText = sqlInsertString;
                    SqlParameter dt = new SqlParameter("@dat", date);
                    SqlParameter intRID = new SqlParameter("@strTypeID", strTypeID);
                    SqlParameter strRType = new SqlParameter("@strRoomType", RoomType);
                    SqlParameter intQuty = new SqlParameter("@intQty", Qty);
                    SqlParameter curpPrice = new SqlParameter("@curPrice", CurPrice);
                    command.Parameters.AddRange(new SqlParameter[] { dt, intRID, strRType, intQuty, curpPrice });
                    command.ExecuteNonQuery();
                }         
            }           
        }
        /*-----------------------------------------------------
        * //AJAY:- Webmethod AmdAvail Amends single Availability for a specified date
        * -----------------------------------------------------*/
        [WebMethod(Description = "Single Update", BufferResponse = true)]
        public DataSet AmdAvail(string Username, string Password, DateTime date, string RoomType, int Qty, double CurPrice)
        {
            GetAuthCredentials(Username, Password);
            int strTypeID = Convert.ToInt16(GetAuthCredentials(Username, Password).Tables[0].Rows[0]["strTypeID"]);
            using (SqlConnection mySQLconnection = new SqlConnection(connStr))
            {
                mySQLconnection.Open();
                using (SqlCommand dbCommand = new SqlCommand())
                {
                    //AJAY:- Just pass a single date to update
                    dbCommand.CommandText = "Update Available set intQty=@Qty,curprice=@CurPrice where dtm = @Dtm and strRoomType=@Roomtype and intResortID=@strTypeID ";
                    dbCommand.Connection = mySQLconnection;
                    //Create new DataAdapter
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = dbCommand;
                        SqlParameter typeI = new SqlParameter("@strTypeID", strTypeID);
                        dbCommand.Parameters.Add(typeI);
                        dbCommand.Parameters.AddWithValue("@Dtm", date);
                        dbCommand.Parameters.AddWithValue("@Qty", Qty);
                        dbCommand.Parameters.AddWithValue("@RoomType", RoomType);
                        dbCommand.Parameters.AddWithValue("@curprice", CurPrice);
                        dbCommand.Parameters.AddWithValue("@username", Username);
                        dbCommand.Parameters.AddWithValue("@password", Password);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }      
            }                     
        }
