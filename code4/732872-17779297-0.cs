    public class MyWrapper
    {
        public ThirdPartyObject ThirdPartyInstance { get; set; }
        
        public MyWrapper()
        {
            ThirdPartyInstance = new ThirdPartyObject("Constructors");
        }
    }
