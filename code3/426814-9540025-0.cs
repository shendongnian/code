    using System;
    using System.IO.IsolatedStorage;
    
    /// <summary>
    /// Application Settings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// IsFirstStart IsolatedStorage Key.
        /// </summary>
        public const string IsFirstStartKey = "firststart";
    
        /// <summary>
        /// Gets or sets a value indicating whether this instance is the first start.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is the first start; otherwise, <c>false</c>.
        /// </value>
        public static bool IsFirstStart
        {
            get
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(AppSettings.IsFirstStartKey))
                    return (bool)IsolatedStorageSettings.ApplicationSettings[AppSettings.IsFirstStartKey];
                else
                    return true;
            }
            set
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(AppSettings.IsFirstStartKey))
                    IsolatedStorageSettings.ApplicationSettings[AppSettings.IsFirstStartKey] = value;
                else
                    IsolatedStorageSettings.ApplicationSettings.Add(AppSettings.IsFirstStartKey, value);
    
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }
    }
    
