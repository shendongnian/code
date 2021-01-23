    public ContentResult ShowNewspaper(long Id) {
        var mySecretURL = db.SecretURLs.Where(k=>k.Id == Id).FirstOrDefault(); // Grab URL entry the database
        string htmlCode = "";
        if(mySecretURL != null) {
             WebClient client = new WebClient();
             htmlCode = client.DownloadString(mySecretURL.URL);
        }else{
             htmlCode = "Page not found!";
        }
        return Content(htmlCode,"text/html");
    }
