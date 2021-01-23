        DataSet2TableAdapters.TableTestTableAdapter t = new DataSet2TableAdapters.TableTestTableAdapter();
        DataSet2 ds = new DataSet2();
        t.Fill(ds.TableTest); 
        foreach (DataSet2.TableTestRow row in ds.TableTest.Rows)
        {
            row.integer = 12345; // change value of column integer               
        }
        t.Update();
