    public ServiceMap Deserialize()
        {
            ServiceMap serviceMap = new ServiceMap();
            try
            {
                using (var fileStream = new FileStream(Settings.ServiceMapPath, FileMode.Open))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.IgnoreComments = true;
                    using (XmlReader reader = XmlReader.Create(fileStream, settings))
                    {
                        serviceMap = _serializer.Deserialize(reader) as ServiceMap;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File 'ServiceMap.xml' could not be found!");
            }
            return serviceMap;
        }
