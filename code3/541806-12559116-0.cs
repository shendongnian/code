        private XElement GetData(DataGridView dgv)
        {
            var elem = new XElement("data");
            foreach (DataGridViewRow row in dgv.Rows)
            {
                elem.Add(new XElement("row",
                    row.Cells
                    .Cast<DataGridViewCell>()
                    .Select(a => new XElement(a.OwningColumn.Name, a.Value))));
            }
            return elem;
        }
