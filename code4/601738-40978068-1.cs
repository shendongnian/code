     HtmlTableRow tRow = new HtmlTableRow();
                for (int i = 1; i < 3; i++)
                {
                    HtmlTableCell tb = new HtmlTableCell();               
                    tb.InnerText = "text";
                    tRow.Controls.Add(tb);
                }
                Table1.Rows.Add(tRow);
