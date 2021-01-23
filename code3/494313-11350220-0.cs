    public class YourNinjectModule: NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            // ===========================================================
            //
            // Bind dependency injection.
            // Add entries in here for any new services or repositories.
            //
            // ===========================================================
            this.Bind<Icontract>().To<contract>();
        }
    }
