            DateTime start = DateTime.Now.Date; //this will get you 2/16/2013 12:00:00am
            DateTime end = start.AddDays(1); //this will get you 2/17/2013 12:00:00am
            //make sure to parameterize your query like this
            string sql = "SELECT * FROM Product WHERE PurchasedDate >= @start AND PurchasedDAte < @end";
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            using (conn)
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, conn);
                System.Data.SqlClient.SqlParameter pmStart = new System.Data.SqlClient.SqlParameter("start", start);
                System.Data.SqlClient.SqlParameter pmEnd = new System.Data.SqlClient.SqlParameter("end", end);
                command.Parameters.Add(pmStart);
                command.Parameters.Add(pmEnd);
            }
