            string path = "IIS://{yourservername}/W3SVC";
            using (DirectoryEntry w3svc = new DirectoryEntry(path))
            {
                foreach (DirectoryEntry entry in w3svc.Children)
                {
                    if (entry.SchemaClassName == "IIsWebServer")
                    {
                        string websiteName = (string)entry.Properties["ServerComment"].Value;
                    }
                }
            }
