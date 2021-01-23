      [DataContract]
        public class Account : Abstracts.Dirty
        {
            #region DataStore fields and singleton
            private static volatile StoreClass _store = new StoreClass();
            protected static StoreClass Store
            {
                get
                {
                    return _store;
                }
            }
            /// <summary>
            /// Store is the data store for the Account class. This holds the active list of Accounts in a singleton, and manages the push/pull to the JSON file storage.
            /// </summary>
            protected class StoreClass : Abstracts.DataStore<Account>
            {
                #region Singleton initialization and Constructor
    
                public StoreClass()
                    : base("accounts.json", "TEMP_accounts.json")
                {
    
                }
                #endregion
            }
        }
