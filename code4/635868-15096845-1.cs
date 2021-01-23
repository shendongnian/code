    [HttpPost]
    public PartialViewResult Add(Car model)
    {
        //now map attribute values from the Car model onto 
        //corresponding attributes of an instance of NewModel
        NewModel new = new NewModel();
        new.ID = model.ID;
        new.UserID = model.UserID;
        new.Desc = model.Description;
        //etc...
        //update your model/db
        _db.Add(new);
        //Redirect however you wish...
    }
