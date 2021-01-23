                ArrayList strings = new ArrayList();
                StreamReader reader = new StreamReader(hostFile);
                while (reader.Peek() > -1)
                {
                    strings.Add(reader.ReadLine());
                }
                reader.Close();
                StreamWriter writer = new StreamWriter(hostFile);
                foreach (String s in strings)
                {
                    if (!s.Contains("255.255.255.255 " + key + " #Blocked by Parental Care"))
                    {
                        writer.Write(s + "\n");
                    }
                }
                writer.Close();
                blockurls.SelectedItems[0].Remove();
                MessageBox.Show("URL Successfully removed");
        }
