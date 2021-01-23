            //for adding the headers to the table
            
            foreach (DataColumn column in dv.Table.Columns)
            {
                HtmlTableCell headerCell = new HtmlTableCell("th");
                headerCell.InnerText = column.Caption;
                if (int.Parse(group[0]) == 1){
                    headerCell.BgColor = "Blue";
                else if (int.Parse(group[0]) == 2)
                    headerCell.BgColor = "Yellow";
                header.Cells.Add(headerCell);
            }
            table.Rows.Add(header);
