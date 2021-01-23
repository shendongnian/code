    Hashtable values = new Hashtable();
                values.Add("margin_left", "0.1");
                values.Add("margin_right", "0.1");
                values.Add("margin_top", "0.1");
                values.Add("margin_bottom", "0.1");
                values.Add("Print_Background", "yes");
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\PageSetup", true))
                {
                    if (key == null)
                        return;
                    foreach (DictionaryEntry item in values)
                    {
                        string value = (string)key.GetValue(item.Key.ToString());
                        if (value != item.Value.ToString())
                        {
                            key.SetValue(item.Key.ToString(), item.Value);
                        }
                    }
                }
