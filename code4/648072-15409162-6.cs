        DataTable[] dt = new DataTable[] { dt1, dt2 };
        XDocument xDoc = new XDocument(new XElement("Root"));
        Func<DataTable, DataRow, IEnumerable<XAttribute>> getAttributes = (t, r) =>
            t.Columns.OfType<DataColumn>().Select(c => new XAttribute(c.ColumnName, r[c].ToString()));
        Func<DataTable, IEnumerable<XElement>> getElements = t =>
            t.Rows.OfType<DataRow>().Select(r => new XElement(htAtributNameForTable[t.TableName], getAttributes(t, r)));
        
        Func<DataTable[], IEnumerable<XElement>> getTables = dtc =>
            dtc.AsEnumerable().Select(t => new XElement(t.TableName, getElements(t)));
        xDoc.Root.Add(getTables(dt));
