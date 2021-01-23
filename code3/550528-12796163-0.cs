       if (settings.Contains(BM_KEY))
            {
                string k = (string) settings[BM_KEY];
                if (k == "1")
                {
                    cb1.IsChecked = true;
                }
                else
                {
                    cb1.IsChecked = false;
                }
            }
            else
            {
                cb1.IsChecked=true;
                settings.Add(BM_KEY,"1"); //exception occurs here
                settings.Save();
            }
