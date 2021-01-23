    public class LicenseManager
    {
        [Import]
        private ILicenseValidator _validator;
    
        [Import]
        private ILicenseSigner _signer;
    
        public LicenseManager()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            var container = new CompsitionContainer(catalog);
            container.ComposeParts(this);
        }
    }
    
    [Export(typeof(ILicenseSigner))]
    public class LicenseSigner : ILicenseSigner
    {
        ...
    }
    
    [Export(typeof(ILicenseValidator))]
    public class LicenseValidator : ILicenseValidator
    {
        ...
    }
