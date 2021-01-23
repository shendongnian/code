            //for adding the headers to the table
            int counter = 0;
            foreach (DataColumn column in dv.Table.Columns)
            {
                HtmlTableCell headerCell = new HtmlTableCell("th");
                headerCell.InnerText = column.Caption;
                
                if (++counter >= 5)
                {
                    if (int.Parse(group[0]) == 1){
                        headerCell.BgColor = "Blue";
                    else if (int.Parse(group[0]) == 2)
                        headerCell.BgColor = "Yellow";
                    header.Cells.Add(headerCell);
                }
            }
            table.Rows.Add(header);
