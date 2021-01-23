    public class DefaultCompositionContainerFactory : ICompositionContainerFactory
    {
        #region Methods
        /// <summary>
        /// Creates an instance of <see cref="CompositionContainer"/>.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="CompositionContainer"/>.
        /// </returns>
        public CompositionContainer CreateCompositionContainer()
        {
            var domain = AppDomain.CurrentDomain;
            string path = domain.BaseDirectory;
            // Use the base directory from where the application is running.
            var catalog = new DirectoryCatalog(path);
            // Create the container.
            var container = new CompositionContainer(catalog);
            return container;
        }
        #endregion
    }
