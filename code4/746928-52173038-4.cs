    this.ColumnHeaders.Add(new ColumnHeaderDescriptor { Header = Properties.Resources.Name, DisplayMember = "ItemName", Width = 250 });
    this.ColumnHeaders.Add(new ColumnHeaderDescriptor { Header = Properties.Resources.ManufPartNumber, DisplayMember = "ManufPartNumber", Width = 150 });
    this.ColumnHeaders.Add(new ColumnHeaderDescriptor { Header = Properties.Resources.LastUnitPrice, DisplayMember = "UnitPriceString", SortMember = "UnitPrice", Width = 90 });
    this.ColumnHeaders.Add(new ColumnHeaderDescriptor { Header = Properties.Resources.AssetType, DisplayMember = "AssetType", Width = 100 });
    this.ColumnHeaders.Add(new ColumnHeaderDescriptor { Header = Properties.Resources.Quantity, DisplayMember = "QuantityString", SortMember = "Quantity", Width = 80 });
