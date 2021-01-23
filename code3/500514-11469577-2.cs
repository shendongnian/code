    public class WebCompositionContainerFactory : ICompositionContainerFactory
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
            string path = HttpRuntime.BinDirectory;
            // Use the base directory from where the application is running.
            var catalog = new DirectoryCatalog(path);
            // Create the container.
            var container = new CompositionContainer(catalog);
            return container;
        }
        #endregion
    }
