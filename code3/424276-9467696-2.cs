     public ActionResult Index()
        {
            List<string> mylist = new List<string>();
            mylist.Add("test2");
            mylist.Add("test3");
            mylist.Add("test4");
    
            IEnumerable<string> myIEnumebrableList = mylist;
    
            return View(myIEnumebrableList);
        }
