    public ActionResult CheckIt()
    {
       List<URLStatusVM> urlList=new List<URLStatusVM>();
      
       string[] urls = {"http://www.google.com","http://www.aaa.com"}
       foreach (string url in urls)
       {
         //Check the status using HttpWebRequest call here
        
         //Create an object of our view model and set the property values
         var item=new URLStatusVM();
         item.URL=url;
         item.Status="Some status text"; //replace with the status from web call
    
         //now add to our list
         urlList.Add(item);
       
        //your foreach loop ends here
       }
       return View(urlList);
    }
