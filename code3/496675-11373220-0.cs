    public static void AddItemsToQueue(string itm)
        {
            evtLogQueue.Enqueue(itm);
            // Add the following code
            if (evtLogQueue.Count == 1000)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Log");
                foreach (var log in evtLogQueue)
                { 
                    DataRow dr = dataTable.NewRow();
                    dr["Log"] = log;
                    dataTable.Rows.Add(dr);
                }
                evtLogQueue.Clear();     // Most probably you will also need to clear the queue.
                SendBulkData(dataTable); // Send the bulk data
            }
        }
