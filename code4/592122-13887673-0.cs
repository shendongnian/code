        DataTable PRODUCT = new DataTable();
        Object lockobj = new Object();
        ParallelOptions parOptions = new ParallelOptions();
        parOptions.MaxDegreeOfParallelism = 5; //use max (5) threads that are allowed.
        Parallel.ForEach(dtPs.AsEnumerable(), parOptions, dtPs_row =>
        {
            try
            { 
                //some declarations
                lock(lockobj)
                {
                    DataRow newProductRow = PRODUCT.NewRow();
                    newProductRow.SetField("ID", mId);
                    newProductRow.SetField("NAME", name);
                    PRODUCT.Rows.Add(newProductRow);
                }
            }
        }
