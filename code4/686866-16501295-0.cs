    [HttpPost]
    public ActionResult LetsTest(FormCollection collection, IEnumerable<Rezultat> rez)
    {
    
        string[] inputs = new string[6];
        for(int i=1; i<8; i++)
       {
           //get all your array inputs
           inputs[i-1]=collection["x["+i+"]"]
       }
    
    }
