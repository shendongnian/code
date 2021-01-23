            public static void UseDataSet(Action<Dataset> code)
            {
                ...
                Dataset dset= new Dataset(); 
 
                try  
                { 
                    dset = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "StoredProcedureName", arParms); 
                    code(dset);
                } 
                catch  
                {  } 
                finally  
                { 
                   Con.Close(); 
                   dset.Dispose() ;
                } 
            }
