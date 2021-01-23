    /// <summary>
        /// Updates a single cell in the specified worksheet.
        /// </summary>
        /// <param name="service">an authenticated SpreadsheetsService object</param>
        /// <param name="entry">the worksheet to update</param>
        private static void UpdateCell(SpreadsheetsService service, WorksheetEntry entry)
        {
            AtomLink cellFeedLink = entry.Links.FindService(GDataSpreadsheetsNameTable.CellRel, null);
            CellQuery query = new CellQuery(cellFeedLink.HRef.ToString());
            Console.WriteLine();
            Console.Write("Row of cell to update? ");
            string row = Console.ReadLine();
            Console.Write("Column of cell to update? ");
            string column = Console.ReadLine();
            query.MinimumRow = query.MaximumRow = uint.Parse(row);
            query.MinimumColumn = query.MaximumColumn = uint.Parse(column);
            CellFeed feed = service.Query(query);
            CellEntry cell = feed.Entries[0] as CellEntry;
            Console.WriteLine();
            Console.WriteLine("Current cell value: {0}", cell.Cell.Value);
            Console.Write("Enter a new value: ");
            string newValue = Console.ReadLine();
            cell.Cell.InputValue = newValue;
            AtomEntry updatedCell = cell.Update();
            Console.WriteLine("Successfully updated cell: {0}", updatedCell.Content.Content);
        }
