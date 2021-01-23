        private void AddItems(Repeater repeater, List<Dog> dogs)
        {
            var repeaterItem = new RepeaterItem(0, ListItemType.Header);
            var table = new HtmlTable();
            var row = new HtmlTableRow();
            var cell1 = new HtmlTableCell("th") { InnerText = "Name" };
            var cell2 = new HtmlTableCell("th") { InnerText = "Breed" };
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            table.Rows.Add(row);
            for (var i = 0; i < repeater.Items.Count; i++)
            {
                repeaterItem = new RepeaterItem(i + 1, ListItemType.Item);
                row = new HtmlTableRow();
                cell1 = new HtmlTableCell() { InnerText = dogs[i].Name };
                cell2 = new HtmlTableCell() { InnerText = dogs[i].Breed };
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                table.Rows.Add(row);
            }
            repeaterItem.Controls.Add(table);
            repeater.Controls.Add(repeaterItem);
        }
