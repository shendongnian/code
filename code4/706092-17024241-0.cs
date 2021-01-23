SqlCommand myCommand = thisConnection.CreateCommand();
                myCommand.CommandText = "FederationUpdateCTRAndImpressionCountsForAllYPIds";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@bid", SqlDbType.UniqueIdentifier);
                myCommand.Parameters.Add("@uid", SqlDbType.UniqueIdentifier);
                myCommand.Parameters.Add("@imp", SqlDbType.VarChar);
                myCommand.Parameters.Add("@ctr", SqlDbType.VarChar);
