        NameTable nameTable = new NameTable();
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(nameTable);
        nsmgr.AddNamespace("z", "#RowsetSchema");
        List<XmlNodeList> rows = (from row in data.AsEnumerable()
                                  select row.SelectNodes("//z:row", nsmgr)).ToList();
