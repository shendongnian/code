    public class SnakeCasePropertyNamesContractResolver :
        DeliminatorSeparatedPropertyNamesContractResolver
    {
        public SnakeCasePropertyNamesContractResolver() : base('_') { }
    }
    
