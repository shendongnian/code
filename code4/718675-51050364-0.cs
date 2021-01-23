        /// <summary>
        ///  Retrieves a translated value from an enumerated list.
        /// </summary>
        /// <param name="value">Enum</param>
        /// <param name="resource">string</param>
        /// <returns>string</returns>
        protected string GetTranslatedEnum(Enum value, string resource)
        {
            string path = String.Format("Resources.{0}", resource);
            ResourceManager resources = new ResourceManager(path, global::System.Reflection.Assembly.Load("App_GlobalResources"));
            if (resources != null) {
                return resources.GetString(value.ToString());
            } else {
                return value.ToString();
            }
        }
