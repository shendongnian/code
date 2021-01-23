    public ActionResult MyAction()
    {
        //some code
    
        ViewBag.Type = TypeProvider.GetType(pk, model.Type);
    
        //return something
    }
    
    class TypeProvider
    {
        Dictionary<string, string> relations = ...
             //a dictionary stores "00"->"14" logics
        public static SomeType GetType(string pk, Type modelType)
        {
            return _reference.Get(relations[pk.SubString(2,2)], modelType).Value;
        }
    }
