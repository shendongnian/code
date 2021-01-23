    // 1 define "delivery" interface
    interface IShippingCompanyService
    {
        void Delivery();
    }
    
    // 2.1 — first assembly "Ups.Services.dll"
    public class ShippingUpsWorldShip : IShippingCompanyService
    {
        public void Delivery()
        {
            "Ship with UPS WorldShip".Dump();
        }
    }
    
    // 2.2 — first assembly "FedEx.Services.dll"
    public class ShippingFedExDesktopApps : IShippingCompanyService
    {
        public void Delivery()
        {
            "Ship with FedEX Desktop Apps".Dump();
        }
    }
    
