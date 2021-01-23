            var fileContents = File.ReadAllText(settingsFile);
            using (var fs = new MemoryStream(Encoding.ASCII.GetBytes(fileContents)))
            {
                var sr = new XmlSerializer(typeof (T));
                var obj = (T) sr.Deserialize(fs);
                fs.Close();
                return obj;
            }
        }
