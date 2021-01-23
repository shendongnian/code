            foreach (XmlNode file in xdoc.SelectNodes("//file"))
            {
                string filename = file.Attributes["name"].Value;
                foreach (XmlNode folder in file.SelectNodes("./ancestor::folder"))
                {
                    string foldername = folder.Attributes["name"].Value;
                    filename = foldername + "\\" + filename;
                }
                System.Diagnostics.Debug.WriteLine(filename);
            }
