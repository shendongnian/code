    redis_write.HMSet(string.Format("u:{0}:info", Request.Cookies["UserID"].Value),
                            new byte[][] { 
                                Encoding.Unicode.GetBytes("Name") ,
                                Encoding.Unicode.GetBytes("Sex") ,
                                Encoding.Unicode.GetBytes("Birth") ,
                                Encoding.Unicode.GetBytes("iURL") ,
                                Encoding.Unicode.GetBytes("Info") ,
                                Encoding.Unicode.GetBytes("RegLocal") 
                            },
                            new byte[][] { 
                                Encoding.Unicode.GetBytes(Request["Name"].ToString()),
                                Encoding.Unicode.GetBytes(Request["Sex"].ToString()),
                                Encoding.Unicode.GetBytes(Request["Birth"].ToString()),
                                Encoding.Unicode.GetBytes(Request["iURL"].ToString()),
                                Encoding.Unicode.GetBytes(Request["Info"].ToString()),
                                Encoding.Unicode.GetBytes(Request["country"].ToString()+","+Request["province"].ToString()+","+Request["city"].ToString())
                            });
