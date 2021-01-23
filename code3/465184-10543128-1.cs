        static MySettings Load()
        {
            var ser = new XmlSerializer(typeof(MySettings));
            MySettings settings = null;
            try
            {
                using (var s = File.OpenRead(path))
                {
                    settings = (MySettings) ser.Deserialize(s);
                    // optionally validate here
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Cannot read settings. " + ex1.Message,
                                "error");
                settings = null;
            }
            return settings;
        }
