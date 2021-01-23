    private static bool IsValidXml(string xmlToCheck)
            {
                var doc = new XmlDocument();
                try
                {
                    doc.LoadXml(xmlToCheck);
                    return true;
                }
                catch (Exception ex)
                {
                    //catch ex.
                    return false;
                }
            }
