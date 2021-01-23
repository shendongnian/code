    private string getName(dynamic anyObjWithName)
    {
        try {
            return anyObjWithName.name;
        }
        catch(RuntimeBinderException) {
            return "{unknown}";
        }
    }
 
