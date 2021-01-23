        public void Initialize()
        {
            if (Report.GlobalParameters != null)
            {
                foreach (KeyValuePair<string, object> kvp in Report.GlobalParameters)
                {
                    PropertyInfo pi = this.GetType().GetProperty(kvp.Key, BindingFlags.Public | BindingFlags.Instance);
                    if (pi != null)
                    {
                        try
                        {
                            pi.SetValue(this, kvp.Value, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(kvp.Key + Environment.NewLine + ex.ToString(), "Error Setting Property Value");
                        }
                    }
                    else
                    {
                        MessageBox.Show(kvp.Key, "Property Not Found");
                    }
                }
            }
        }
