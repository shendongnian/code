    protected void getGeoCoding()
            {
                string postalCode = string.Empty;
                string glat = string.Empty;
                string glong = string.Empty;
                string gPostal = string.Empty;
                string sqlUpdateQuery = string.Empty;
                string sqlGetQuery = string.Empty;
    
                string json = DAO.getNullLatLong();
                JObject jobject = JObject.Parse(json);
                JArray items = (JArray)jobject["e"];
    
                JObject item;
                JToken jtoken;
    
                string connectionString = DAO.GetConnectionString();
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();
    
                
                 for (int i = 0; i < items.Count; i++) //loop through rows
                 {
                     item = (JObject)items[i];
                     jtoken = item.First;
    
                  while (jtoken != null)//loop through columns
                  {
               
                    postalCode = item["postalCode"].ToString();
                    string url = "https://maps.googleapis.com/maps/api/geocode/json?sensor=false&address=Singapore%20";
                    dynamic googleResults = new Uri(url + postalCode).GetDynamicJsonObject();
    
                  
                    foreach (var result in googleResults.results)
                    {
                        glat += result.geometry.location.lat;
                        glong += result.geometry.location.lng;
                        gPostal += postalCode;
    
                        sqlUpdateQuery = "update latlongDB set lat =@lat,long =@long where postalCode =@postal";
                        SqlCommand updateCommand = new SqlCommand(sqlUpdateQuery, sqlConn);
                        updateCommand.Parameters.Add("@lat", SqlDbType.NVarChar).Value = glat;
                        updateCommand.Parameters.Add("@long", SqlDbType.NVarChar).Value = glong;
                        updateCommand.Parameters.Add("@postal", SqlDbType.NVarChar).Value = gPostal;
                        updateCommand.ExecuteNonQuery();
                    }
                   
                }
    
    
                  jtoken = jtoken.Next;    
                }
    
    
      
    
            }
