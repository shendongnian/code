    public class ErrorCounter
	{
        private List<string> _propertiesError = new List<string>();
        private static ObjectIDGenerator _IDGenerator = new ObjectIDGenerator();
        public bool HasErrors
        {
            get => ErrorCount != 0;
        }
        public int ErrorCount
        {
            get => _propertiesError.Count;
        }
        /// <summary>
        /// Record object validation rule state.
        /// </summary>
        /// <param name="sender">"this" object reference must be passed into parameter each time SetError is called</param>
        /// <param name="message"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public string SetError(object sender, string property, string message)
        {
            string propertyUniqueID = GetPropertyUniqueID(sender, property);
            if (string.IsNullOrWhiteSpace(message))
            {
                if (_propertiesError.Exists(x => x == propertyUniqueID))
                {
                    _propertiesError.Remove(propertyUniqueID);
                }
            }
            else
            {
                if (!_propertiesError.Exists(x => x == propertyUniqueID))
                {
                    _propertiesError.Add(propertyUniqueID);
                }
            }
            return message;
        }
        private string GetPropertyUniqueID(object sender, string property)
        {
            bool dummyFirstTime;
            return property + "_" + _IDGenerator.GetId(sender, out dummyFirstTime);
        }
    }
