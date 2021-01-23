    string firstName;
            string lastName;
            using (XmlTextReader reader = GetDebugInfo())
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name == "student")
                    {
                        reader.ReadToDescendant("firstName");
                        reader.Read();
                        firstName = reader.Value;
                        reader.ReadToFollowing("lastName");
                        reader.Read();
                        lastName = reader.Value;
                        AddStudent(firstName, lastName);
                    }
                }
            }
