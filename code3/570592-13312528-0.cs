     public interface IRepository<T>
    {
        /// <summary>
        /// Saves the specified object and returns it back to the user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The created class</returns>
        T Add(T model);
        /// <summary>
        /// Persist the specified object.
        /// </summary>
        /// <param name="model">The model.</param>
        void Save(T model);
    }
