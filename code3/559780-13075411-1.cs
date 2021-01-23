    public ActionResult SomeAction() {
      // call other section logic using HttpWebRequest or WebClient
      // /controller/emailsection/{vars}/......
      // Get the string out of the request add it to ViewData["xxx"]
      // rinse and repeat for other sections
      
    }
    public ActionResult EmailSection() {
      //put section logic here
      Response.ContentType = "text/html"; // "text/plain"
      Response.Write("Some HttpWebResponse");
      return null;
    }
