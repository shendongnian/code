        public static List<LitePropertyData> GetProperties(XElement record)
        {
            if (record.Element("Properties") == null) return new List<LitePropertyData>();
            if (record.Descendants("Properties")== null) return new List<LitePropertyData>();
            if (record.Descendants("Properties").Descendants("LitePropertyData") == null) return new List<LitePropertyData>();
            List<LitePropertyData> properties =
            (from property in record.Descendants("Properties").Descendants("LitePropertyData")
             select new LitePropertyData
             {
                 Description = property.Element("Description").Value,
                 DisplayEditUI = property.Element("DisplayEditUI").Value.ToBoolean(),
                 DisplayName = property.Element("DisplayName").Value,
                 FieldOrder = property.Element("FieldOrder").Value.ToInt32(),
                 IsModified = property.Element("IsModified").Value.ToBoolean(),
                 IsRequired = property.Element("IsRequired").Value.ToBoolean(),
                 Name = property.Element("Name").Value,
                 OwnerTab = property.Element("OwnerTab").Value.ToInt32(),
                 ParentPageID = property.Element("ParentPageID").Value.ToInt32(),
                 Type = (LiteDataType)property.Element("Type").Value.ToInt32(),
                 Value = property.Element("Value").Value,
             }).ToList();
            return properties;
        }
        /// <summary>
        /// Gets the pages.
        /// </summary>
        /// <param name="xmlFullFilePath">The XML full file path.</param>
        /// <returns></returns>
        public static List<LitePageData> GetPages(String xmlFullFilePath)
        {
            XDocument document = XDocument.Load(xmlFullFilePath);
            List<LitePageData> results = (from record in document.Descendants("row")
                                          select new LitePageData
                                          {
                                              Guid = IsValid(record, "Guid") ?
                                                record.Element("Guid").Value :
                                                null,
                                              ParentID = IsValid(record, "ParentID") ?
                                                    Convert.ToInt32(record.Element("ParentID").Value) :
                                                    (Int32?)null,
                                              Created = Convert.ToDateTime(record.Element("Created").Value),
                                              Changed = Convert.ToDateTime(record.Element("Changed").Value),
                                              Name = record.Element("Name").Value,
                                              ID = Convert.ToInt32(record.Element("ID").Value),
                                              LitePageTypeID = IsValid(record, "ParentID") ?
                                                    Convert.ToInt32(record.Element("ParentID").Value) :
                                                    (Int32?)null,
                                              Html = record.Element("Html").Value,
                                              FriendlyName = record.Element("FriendlyName").Value,
                                              Properties = GetProperties(record),
                                              //record.Element("Properties") != null ? record.Element("Properties").FromXElement<List<LitePropertyData>>() :
                                              //  new List<LitePropertyData>()
                                          }).ToList();
            return results;
        }
