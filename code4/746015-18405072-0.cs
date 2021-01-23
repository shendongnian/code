            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] resources = assembly.GetManifestResourceNames();
            foreach (string resource in resources)
            {
                if(resource.EndsWith(".xsd"))
                {
                    Stream stream = assembly.GetManifestResourceStream(resource);
                    if (stream != null)
                    {
                        XmlSchema schema = XmlSchema.Read(stream, null);
                        _schemas.Add(schema);
                    }
                }
            }
