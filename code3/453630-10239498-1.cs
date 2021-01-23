    /*step 1*/if ((info.Length / 1024) > 1500000)
                    {//my size checking and storing it in an array
                        files.Add(sysInfo.Name.ToString());
                        files1.Add(info.Length.ToString());
                    }
    /*step2*/mailMessage.Body = "THE FILES : <br/><br/>";
    for(int i=0; i<files.Count; i++)
      mailMessage.Body += files[i] + " = " + files1[i] + "<br/>;
    mailMessage.Body += "<br/> HAS REACHED ITS SIZE LIMIT!!";
