    public class Global : NinjectWcfApplication
    {
        #region Overrides of NinjectWcfApplication
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel( new ServiceModule() );
            return kernel;
        }
        #endregion
    }
