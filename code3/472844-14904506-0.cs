    public void CheckForCells()
    {
        Table table = Document.Table(Find.ById("MyTableID"));
        int counter = 0;
        while (table.TableRows.Count < 5 && counter < 50)
        {
            table.Refresh();
            counter++;
            System.Threading.Thread.Sleep(10);
        }
    }
