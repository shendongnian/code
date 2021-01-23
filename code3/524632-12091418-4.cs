        [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
        internal sealed class BuildInfoAttribute : Attribute 
        {
            public string UserName
            {
                get; private set;
            }
            public string BuildDate
            {
                get; private set;
            }
            public BuildInfoAttribute(string username, string buildDate)
            {
                UserName = username;
                BuildDate = buildDate;
            }
        }
