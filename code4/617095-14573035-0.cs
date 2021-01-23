    public static class HelperExtensions
    {
    	//Note the interface goes here 
        public static void WriteResponse(this IAuxiliaryHelper helper, 
                                         object jsonObj)
        { 
            //omn nom nom
    	}
    }
    
    //somewhere else - usage
    IAuxiliaryHelper h = new Foo();
    h.WriteResponse(new JsonObject());
