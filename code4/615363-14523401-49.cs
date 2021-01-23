    public ActionResult Get(int UserID)
        { 
            
            var User1 = new User {UserID = UserID };
            User1.LoadFile();
      
       //If file exists....
            MemoryStream ms = new MemoryStream(User1.File.Content, 0, 0, true, true);
            Response.ContentType = User1.File.Type;
            Response.AddHeader("content-disposition", "attachment;filename=" + User1.File.Name);
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();
            return new FileStreamResult(Response.OutputStream, User1.File.Type);
            
        }
