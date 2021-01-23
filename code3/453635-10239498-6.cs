    /*step 1*/if ((info.Length / 1024) > 1500000)
                    {//my size checking and storing it in an array
                        files.Add(sysInfo.Name.ToString());
                        files1.Add(info.Length.ToString());
                        arr = string.Join("<br/>", files.ToArray());
                        arr1 = string.Join("<br/>", files1.ToArray());
                    }
    /*step 2*/mailMessage.Body = "THE FILES : <br/><br/>" + arr + arr1 + "<br/><br/> HAS REACH ITS SIZE LIMIT!!";
