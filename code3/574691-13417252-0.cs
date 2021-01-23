    class IntermdeiateModel
    {
         public float x+property {get;set;}
    }
    ....
    return Serializer.Serialze(GetAllEamples().Select(e => new IntermdeiateModel { x_property = e.x_property));
