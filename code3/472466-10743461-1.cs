    private string getListOfFileNames(DataTable listWithFileNames)
    {
        string whereClause = String.Empty;
        if (listWithFileNames.Columns.Contains("Filename"))
        {
            int nthreads = 8; // You can play with this parameter to fine tune and get your best time.
            int load = listWithFileNames.Rows.Count / nthreads; // This will tell how many items reach thread mush process.
            List<ManualResetEvent> mres = new List<ManualResetEvent>(); // This guys will help the method to know when the work is done.
            List<StringBuilder> sbuilders = new List<StringBuilder>(); // This will be used to concatenate each bis string.
            for (int i = 0; i < nthreads; i++)
            {
                sbuilders.Add(new StringBuilder()); // Create a new string builder
                mres.Add(new ManualResetEvent(false)); // Create a not singaled ManualResetEvent.
                    
                if (i == 0) // We know were to put the very begining of your where clause
                {
                    sbuilders[0].Append("where filename in (");
                }
                // Calculate the last item to be processed by the current thread
                int end = i == (nthreads - 1) ? listWithFileNames.Rows.Count : i * load + load;
                // Create a new thread to deal with a part of the big table.
                Thread t = new Thread(new ParameterizedThreadStart((x) =>
                {
                    // This is the inside of the thread, we must unbox the parameters
                    object[] vars = x as object[];
                    int lIndex = (int)vars[0];
                    int uIndex = (int)vars[1];
                    ManualResetEvent ev = vars[2] as ManualResetEvent;
                    StringBuilder sb = vars[3] as StringBuilder;
                    bool coma = false;
                    // Concatenate the rows in the string builder
                    for (int j = lIndex; j < uIndex; j++)
                    {
                        if (coma)
                        {
                            sb.Append(", ");
                        }
                        else
                        {
                            coma = true;
                        }
                        sb.Append("'").Append(listWithFileNames.Rows[j]["Filename"]).Append("'");
                    }
                        
                    // Tell the parent Thread that your job is done.
                    ev.Set();
                }));
                // Start the thread with the calculated params
                t.Start(new object[] { i * load, end, mres[i], sbuilders[i] });
            }
            // Wait for all child threads to finish their job
            WaitHandle.WaitAll(mres.ToArray());
            // Concatenate the big string.
            for (int i = 1; i < nthreads; i++)
            {
                sbuilders[0].Append(", ").Append(sbuilders[i]);
            }
                
            sbuilders[0].Append(")"); // Close your where clause
            // Return the finished where clause
            return sbuilders[0].ToString();
        }
        // Returns empty
        return whereClause;
    }
