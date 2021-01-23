    using System;
    using System.Net;
    using System.Windows;
    using System.IO.IsolatedStorage;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    namespace YourProjectNamespace
    {
        public class AppSettings
        {
            // Isolated storage settings
            private IsolatedStorageSettings m_isolatedStore;
    
            public AppSettings()
            {
                try
                {
                    // Get the settings for this application.
                    m_isolatedStore = IsolatedStorageSettings.ApplicationSettings;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception while using IsolatedStorageSettings: " + e.ToString());
                }
            }
    
            /// <summary>
            /// Update a setting value for our application. If the setting does not
            /// exist, then add the setting.
            /// </summary>
            /// <param name="Key">Key to object</param>
            /// <param name="value">Object to add</param>
            /// <returns>if value has been changed returns true</returns>
            public bool AddOrUpdateValue(string Key, Object value)
            {
                bool valueChanged = false;
    
                try
                {
                    if (m_isolatedStore.Contains(Key))
                    {
                        // if new value is different, set the new value.
                        if (m_isolatedStore[Key] != value)
                        {
                            m_isolatedStore[Key] = value;
                            valueChanged = true;
                        }
                    }
                    else
                    {
                        m_isolatedStore.Add(Key, value);
                        valueChanged = true;
                    }
                }
                catch (ArgumentException)
                {
                    m_isolatedStore.Add(Key, value);
                    valueChanged = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception while using IsolatedStorageSettings: " + e.ToString());
                }
    
                return valueChanged;
            }
    
            /// <summary>
            /// Get the current value of the setting, or if it is not found, set the 
            /// setting to an empty List.
            /// </summary>
            /// <typeparam name="valueType"></typeparam>
            /// <param name="Key"></param>
            /// <returns></returns>
            public List<DefType> GetListOrDefault<DefType>(string Key)
            {
                try
                {
                    if (m_isolatedStore.Contains(Key))
                    {
                        return (List<DefType>)m_isolatedStore[Key];
                    }
                    else
                    {
                        return new List<DefType>();
                    }
                }
                catch (ArgumentException)
                {
                    return new List<DefType>();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception while using IsolatedStorageSettings: " + e.ToString());
                }
    
                return new List<DefType>();
            }
    
            public List<String> Messages
            {
                get
                {
                    return this.GetListOrDefault<String>("Messeges");
                }
    
                set
                {
                    this.AddOrUpdateValue("Messeges", value);
                    this.Save();
                }
            }
    
            /// <summary>
            /// Delete all data
            /// </summary>
            public void DeleteAll()
            {
                m_isolatedStore.Clear();
            }
    
            /// <summary>
            /// Save the settings.
            /// </summary>
            public void Save()
            {
                m_isolatedStore.Save();
            }
        }
    }
