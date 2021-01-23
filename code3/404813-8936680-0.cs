    SqlCommand cmd = new SqlCommand((@"SELECT DISTINCT " +
                                        "tblSBT.sname," +
                                        "tblSBDetails.sid," + 
                                        "tblSBDetails.assignedtrack," + 
                                        "tblSBDetails.maxtrack," + 
                                        "tblSBDetails.currentvals," + 
                                        "tblSBDetails.maxvals," + 
                                        "tblSBDetails.lastupdated" +
                                        " FROM" +         
                                            " tblSBT (NOLOCK)" +
                                        " LEFT OUTER JOIN" +
                                            " tblSBDetails (NOLOCK)" +
                                        " ON" +
                                            " tblSBT.sid = tblSBDetails.sid" +                      
                                        " WHERE" +
                                        " tblSBDetails.lastupdated > DateADD(n, -5, GETDATE())"+
                                        " ORDER BY" +
                                        " tblSBT.sname" +), cn); 
