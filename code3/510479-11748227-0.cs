    using System;
    namespace YOUR_NAMESPACE_HERE
    {
      /// <summary>
      /// IOC object for stubbing System.Configuration.AppSettingsReader.
      /// Provides a method for reading values of a particular type from
      /// the configuration.
      /// </summary>
      interface IAppSettingsReader
      {
        /// <summary>
        /// Gets the value for a specified key from the
        /// System.Configuration.ConfigurationSettings.AppSettings property
        /// and returns an object of the specified type containing the
        /// value from the configuration.
        /// </summary>
        /// <param name="key">The key for which to get the value.</param>
        /// <param name="type">The type of the object to return.</param>
        /// <returns>The value of the specified key</returns>
        /// <exception cref="System.ArgumentNullException">key is null.
        /// - or -
        /// type is null.</exception>
        /// <exception cref="System.InvalidOperationException">key does
        /// not exist in the &lt;appSettings&gt; configuration section.
        /// - or -
        /// The value in the &lt;appSettings&gt; configuration section
        /// for key is not of type type.</exception>
        public object GetValue(string key, Type type);
      }
    }
