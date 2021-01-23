            XmlNodeList items = xDoc.SelectNodes("item");
            foreach (XmlNode xItem in items)
            {
                string id = xItem.Attributes["id"].Value;
                string href= xItem.Attributes["href"].Value;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
