                string MyConString = "DRIVER={MySQL ODBC 3.51 Driver};" +
                                      "SERVER=112.***.**.***;" +
                                      "DATABASE=dbname;" +
                                      "UID=u_name;" +
                                      "PASSWORD=u_pass;port=3306;" +
                                      "OPTION=3";
                OdbcConnection MyConnection = new OdbcConnection(MyConString);
                MyConnection.Open();
