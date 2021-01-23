    public ResumingFileStreamResult Viking (string file)
     {
      moviename = Server.MapPath("~/Content/samples/" + file);
      FileStream fs = new FileStream(moviename, FileMode.Open, FileAccess.Read);
      ResumingFileStreamResult fsr = new ResumingFileStreamResult(fs,"video/mp4");
      return fsr;
    }
 
