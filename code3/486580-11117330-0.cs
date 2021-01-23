        /// <summary>
        /// Gets the instance of Type T from the Ninject Kernel
        /// </summary>
        /// <typeparam name="T">The Type which is requested</typeparam>
        /// <returns>An instance of Type T from the Kernel</returns>
        public static T GetInstance<T>()
        {
            return (T)Kernel.Get(typeof(T));
        }
