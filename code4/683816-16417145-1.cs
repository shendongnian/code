    public string DoJson(){
        var pers = new Person();
        pers.edad = 1;
        pers.nombre = "Name";
        System.Web.Script.Serialization.JavaScriptSerializer oSerializer = 
                new System.Web.Script.Serialization.JavaScriptSerializer();
        return  oSerializer.Serialize(pers);
    }
