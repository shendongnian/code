            Table table = ie.Table(Find.ById(TableId));
            Regex regex = new Regex(data + @".*");
            if (table.TableCell(Find.ByText(regex)).Exists)
            {
                TableRow tr = table.TableCell(Find.ByText(regex)).ContainingTableRow;
                return tr;
            }
            else
            {
                int n = table.Tables[table.Tables.Count - 1].Links.Count;
                if (page < n)
                {
                    table.Tables.First().Links[page].Click();
                    ie.WaitForComplete();
                    System.Threading.Thread.Sleep(5000);
                    return (SearchTable(TableId, data, page + 1));
                }
                else
                    return null;
            }
        }
