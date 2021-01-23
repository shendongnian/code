    /// <summary>
    /// Defines the required contract for implementing a composition container factory.
    /// </summary>
    public interface ICompositionContainerFactory
    {
        #region Methods
        /// <summary>
        /// Creates an instance of <see cref="CompositionContainer"/>.
        /// </summary>
        /// <returns>An instance of <see cref="CompositionContainer"/>.</returns>
        CompositionContainer CreateCompositionContainer();
        #endregion
    }
