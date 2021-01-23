    public ActionResult Index()
      {  
            // div "mudetails" should not apper
            mudetails.Visible = false;
            return View();
        }
    public ActionResult Index(string textbox)
        {
               // div "mudetails" should apper
                  mudetails.Visible = true;
    }
