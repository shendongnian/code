    enum MANUFACTURERS
    {
        SAMSUNG,
        HTC,
        NOKIA
    }
    class PhoneTypeChecker
    {
        IPhoneFactory factory;
        ...
        public PhoneTypeChecker(MANUFACTURERS m)
        {
            m_manufacturer= m;
        }
        public void CheckProducts()
        {
            switch (m_manufacturer)
            {
                case MANUFACTURERS.SAMSUNG:
                    factory = new SamsungFactory();
                    break;
                case MANUFACTURERS.HTC:
                    factory = new HTCFactory();
                    break;
                case MANUFACTURERS.NOKIA:
                    factory = new NokiaFactory();
                    break;
            }
            ...
            factory.GetSmart();
            factory.GetDumb();
            ...
        }
    }
    
    static void Main(string[] args)
    {
        PhoneTypeChecker checker = new PhoneTypeChecker(MANUFACTURERS.SAMSUNG);
        checker.CheckProducts();
    
        ...
    }
