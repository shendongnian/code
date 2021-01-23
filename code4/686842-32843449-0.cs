    public void ExportToCSV()
            {
                StringWriter sw = new StringWriter();
    
                sw.WriteLine("\"First Name\",\"Last Name\",\"Email\",\"Organisation\",\"Department\",\"Job Title\"");
                
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=registereduser.csv");
                Response.ContentType = "application/octet-stream";
    
                ApplicationDbContext db = new ApplicationDbContext();
    
                var users = db.Users.ToList();
    
                foreach (var user in users)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\"",
                    
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.Organisation,
                    user.Department,
                    user.JobTitle
                    ));
                }
                Response.Write(sw.ToString());
                Response.End();
    
            }
