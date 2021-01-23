    using System.Collections;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Threading;
    public class ResourceHelper
    {
        /// <summary>
        ///     ResourceHelper
        /// </summary>
        /// <param name="resourceName">i.e. "Namespace.ResourceFileName"</param>
        /// <param name="assembly">i.e. GetType().Assembly if working on the local assembly</param>
        public ResourceHelper(string resourceName, Assembly assembly)
        {
            ResourceManager = new ResourceManager(resourceName, assembly);
        }
        private ResourceManager ResourceManager { get; set; }
        public string GetResourceName(string value)
        {
            DictionaryEntry entry = ResourceManager.GetResourceSet(Thread.CurrentThread.CurrentCulture, true, true).OfType<DictionaryEntry>().FirstOrDefault(dictionaryEntry => dictionaryEntry.Value.ToString() == value);
            return entry.Key.ToString();
        }
        public string GetResourceValue(string name)
        {
            string value = ResourceManager.GetString(name);
            return !string.IsNullOrEmpty(value) ? value : null;
        }
    }
