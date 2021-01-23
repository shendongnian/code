    /*step 1*/if ((info.Length / 1024) > 1500000)
                    {//my size checking and storing it in an array
                        /* I suppose there is a Dictionary<string, string> MyFiles;
                        MyFiles = new Dictionary<string,string>(); instantiated like so*/
                        MyFiles.add(sysInfo.Name.ToString(), info.Length.ToString());
                    }
                    //attaching the array to the email body
                        /*step 2*/mailMessage.Body = "THE FILES : <br/><br/>";
                        foreach(string key in MyFiles.Keys)
                        {
                          mailMessage.Body += key + " = " + MyFiles[key] + <br/>;
                        }
                        mailMessage.Body += "<br/> HAS REACHED ITS SIZE LIMIT!!";
