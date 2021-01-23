    public IEnumberable<myObject> GetObjectsFromApiCall(){
        for(var i = 0; i < 10; i++)
        {
             yield return new myObject();
        }
    }
