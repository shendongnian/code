        public int Queue()
            {
            
                    using (Entities server = new Entities())
                    {
    int retVal=0;//initialize it your value
                        var ServerId1 = (from serverID in server.AppPM_Patches
                                         where serverID.PatchStatus == "NotStarted" && serverID.ServerId == 1
                                         select serverID.ServerId).Count();
                        var ServerId2 = (from serverID in server.AppPM_Patches
                                         where serverID.PatchStatus == "NotStarted" && serverID.ServerId == 2
                                         select serverID.ServerId).Count();
                        var ServerId3 = (from serverID in server.AppPM_Patches
                                         where serverID.PatchStatus == "NotStarted" && serverID.ServerId == 3
                                         select serverID.ServerId).Count();
                        if (ServerId1 == 0 && ServerId2 == 0 && ServerId3 == 0)
                        {
                            retVal=ServerId1;//Convert.ToInt32(ServerId1);
            
                        }
                        else if (ServerId1 == 1 && ServerId2 == 0 && ServerId3 == 0)
                        {
                            retVal=ServerId2;
                        }
                        else if (ServerId1 == 1 && ServerId2 == 1 && ServerId3 == 0)
                        {
                            retVal=ServerId3;
                        }
                        else if (ServerId1 > ServerId2 && ServerId1 > ServerId3)
                        {
                            if (ServerId2 > ServerId3)
                            {
                                retVal= ServerId3;
                            }
                            else
                            {
                                retVal=ServerId2;
                            }
                        }
                        else if (ServerId2 > ServerId3 && ServerId2 > ServerId1)
                        {
                            if (ServerId1 > ServerId3)
                            {
                                retVal=ServerId3;
                            }
                            else
                            {
                                retVal=ServerId1;
                            }
                        }
                        else if (ServerId3 > ServerId1 && ServerId3 > ServerId2)
                        {
                            if (ServerId1 > ServerId2)
                            {
                                retVal=ServerId2;
                            }
                            else
                            {
                                retVal=ServerId1;
                            }
                        }
                        else if (ServerId1 == ServerId2 && ServerId2 == ServerId3 && ServerId1 == ServerId3)
                        {
                            retVal=ServerId1;
                        }
                        else if (ServerId1 == ServerId2 && ServerId1 > ServerId3 && ServerId2 > ServerId3)
                        {
                            retVal=ServerId3;
                        }
                        else if (ServerId2 == ServerId3 && ServerId2 > ServerId1 && ServerId3 > ServerId1)
                        {
                            retVal=ServerId1;
                        }
                        else if (ServerId1 == ServerId3 && ServerId1 > ServerId2 && ServerId1 > ServerId3)
                        {
                            retVal=ServerId1;
                        }
            
            return retVal;
                    }
            }
