            var importedData = new List<ImportRow>();
            foreach (DataRow oldRow in originalTable.Rows)
            {
                var newRow = new ImportRow();
                newRow.Status = oldRow["status"].ToString();
                newRow.DateDue = Convert.ToDateTime(oldRow["date_due"].ToString());
                newRow.DateOrdered = Convert.ToDateTime(oldRow["date_ordered"].ToString());
                importedData.Add(newRow);
            }
