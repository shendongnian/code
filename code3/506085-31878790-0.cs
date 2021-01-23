        public static void SaveLastLocation(this Form form, string UniqueName)
        {
            FormWindowState CurState = form.WindowState;
            if (CurState == FormWindowState.Minimized)
                CurState = FormWindowState.Normal;
            form.WindowState = FormWindowState.Normal;
            if (Properties.Settings.Default.WindowSettings == null)
                Properties.Settings.Default.WindowSettings = new System.Collections.Specialized.StringCollection();
            
            if(Properties.Settings.Default.WindowSettings.Count > 0)
                foreach (string S in Properties.Settings.Default.WindowSettings)
                    if (S.Split('|').First().ToLower() == UniqueName.ToLower())
                    {
                        Properties.Settings.Default.WindowSettings.Remove(S);
                        break;
                    }
            Properties.Settings.Default.WindowSettings.Add(string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                UniqueName, form.Top.ToString(), form.Left.ToString(), form.Height.ToString(), form.Width.ToString(), form.WindowState.ToString()));
            Properties.Settings.Default.Save();
        }
        public static void RestoreLastLocation(this Form form, string UniqueName)
        {
            if (Properties.Settings.Default.WindowSettings != null && Properties.Settings.Default.WindowSettings.Count > 0)
                foreach (string S in Properties.Settings.Default.WindowSettings)
                {
                    string[] Parts = S.Split('|');
                    if (Parts[0].ToLower() == UniqueName.ToLower())
                    {
                        form.Top = int.Parse(Parts[1]);
                        form.Left = int.Parse(Parts[2]);
                        form.Height = int.Parse(Parts[3]);
                        form.Width = int.Parse(Parts[4]);
                        form.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), Parts[5]);
                        break;
                    }
                }
        }
     
