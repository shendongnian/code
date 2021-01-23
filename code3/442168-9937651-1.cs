    // Create your datatable.
    
    DataTable dt = new DataTable();
    dt.Columns.Add("Title", typeof(string));
    dt.Columns.Add("Street", typeof(double));
    
     
    // get a list of object arrays corresponding
    // to the objects listed in the columns
    // in the datatable above.
    var result = from p in in this.GetData().Cast<IContent>()             
                 select dt.LoadDataRow(
                    new object[] { Title = item.GetMetaData("Title"),
                                  Street = item.GetMetaData("Street"),
                     },
                    false);
    
     
    // the end result will be a set of DataRow objects that have been
    // loaded into the DataTable. 
