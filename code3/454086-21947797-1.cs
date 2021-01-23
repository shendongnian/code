            string query = @"SELECT cs.Status, cs.Completed
          FROM NC_Steps s
          INNER JOIN NC_ClientSteps cs
              ON cs.RecID = s.RecID
          WHERE cs.ClientID = 162
          AND s.RecID = @value";
           //you can add more parameters by adding commas
           var parameters = new SqlParameter[] {
                new SqlParameter("@value", RecID )
               };
            SqlDataReader dr = executeReader(query, parameters);
            while (dr.Read())
            {
                //fill your controls with data 
            }
            dr.Close();
