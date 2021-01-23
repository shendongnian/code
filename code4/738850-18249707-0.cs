    using (SqlDataReader dr = command.ExecuteReader())
                            {
                                //  Check if we have data or not - no need to create the excel file if no data
                                if (!dr.HasRows)
                                {
                                    JSONdata = null;
                                    return false;
                                }
    
                                StringBuilder json = new StringBuilder();
                                string LastGroup = null;
                                bool Init = true;
    
                                json.AppendLine("{");
    
                                while (dr.Read())
                                {
                                    if (Init)
                                    {
                                        json.AppendLine("\"name\": \"" + dr["Organisation"] + "\",");
                                        json.AppendLine("\"children\": ");
                                        json.AppendLine("[");
                                    }
                                    if (LastGroup != dr["GroupIdentifier"].ToString())
                                    {
                                        if (Init == true)
                                        {
                                            json.AppendLine("{");
                                            json.AppendLine("\"name\": \"" + dr["GroupIdentifier"] + "\",");
                                            json.AppendLine("\"children\":");
                                            json.AppendLine("[");
                                            Init = false;
                                        }
                                        else
                                        {
                                            var index = json.ToString().LastIndexOf(',');
                                            if (index >= 0)
                                            {
                                                json.Remove(index, 1);
                                            }
                                            json.AppendLine("]");
                                            json.AppendLine("},");
                                            json.AppendLine("{");
                                            json.AppendLine("\"name\": \"" + dr["GroupIdentifier"] + "\",");
                                            json.AppendLine("\"children\":");
                                            json.AppendLine("[");
                                        }
                                        LastGroup = dr["GroupIdentifier"].ToString();
                                    }
    
                                    json.AppendLine("{\"name\": \"" + dr["Measure"] + "\", \"size\": " + dr["MeasureValue"].ToString() + "},");
                                }
    
                                var index2 = json.ToString().LastIndexOf(',');
                                if (index2 >= 0)
                                {
                                    json.Remove(index2, 1);
                                }
                                json.AppendLine("]");
                                json.AppendLine("}");
    
                                json.AppendLine("]");
                                json.AppendLine("}");
    
                                JSONdata = json.ToString();
                                return true;
    
                            } // end SqlRdr
