    internal class PcTabletAslaptop : LaptopBase
    {
        // here is you can expose / override laptop specific stuff
    }
    
    internal class PcTabletAsSmartphone : SmartphoneBase
    {
        // here is you can expose / override smartphone specific stuff
    }
        
    public interface IPcTablet
    {
       // just expose PcTablet specific API
    }
    public sealed class PcTablet : IPcTablet
    {
       private PcTabletAsSmartphone asSmartphone;
       private PcTabletAsLaptop asLaptop;
    }
