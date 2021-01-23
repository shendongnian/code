    [HttpPost()]
    public ActionResult GetAsiguratiSuplimentari(string model)
    {
    	List<myModel> myModel = JsonConvert.DeserializeObject<List<muModel>>(model);
    }
