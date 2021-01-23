    public void GenerateHTMLClass(string xmlfileaddress, string htmlfilenaddress)
            {
                List<string> id = new List<string>();
                List<string> name = new List<string>();
                List<string> type = new List<string>();
                List<string> value = new List<string>();
                string htmlstring = "";
                XmlTextReader reader = new XmlTextReader(xmlfileaddress);
              
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "GUID":
                            id.Add(reader.ReadString());
                            break;
                        case "Title":
                            name.Add(reader.ReadString());
                            break;
                        case "Type":
                            type.Add(reader.ReadString());
                            break;
                    }
                }
                int i=0;
                foreach (var item in id)
                {
                    htmlstring += "<" + type[i] + " id=" + item + " value=" + name[i] + "/>" + name[i] + "</" + type[i] + ">";
                    i++;
                }
                using (FileStream fs = new FileStream(htmlfilenaddress, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                    {
                        writer.Write(htmlstringbegin + htmlstring + htmlstringend);
                    }
                }
            }
