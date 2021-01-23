    while (objDataReader.Read())
                    {
    					objM = new Member();
                        
    					if(objDataReader["Id"] != DBNull.Value)
    					    objM.Id = Convert.ToInt32(objDataReader["Id"]);
    
    					list.Add(objM );
                    }
                 return list;
