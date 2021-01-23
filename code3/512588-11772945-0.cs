    public ActionResult PrintOutput(sting str)
    {
       Modalclass myObject = new Modalclass(); 
       myObject.load(str);
    
       ViewBag.myObject = myObject; //probably at least ToString() call is due here
       return View();
    }
