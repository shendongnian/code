                string filePathStudent = System.IO.Path.GetFullPath("StudentInfo.txt");
            DataTable studentDataTable = new DataTable();
            studentDataTable.Columns.Add("Id", typeof(Int32));
            studentDataTable.Columns.Add("StudentID");
            studentDataTable.Columns.Add("FirstName");
            studentDataTable.Columns.Add("LastName");
            studentDataTable.Columns.Add("StreetAdd");
            studentDataTable.Columns.Add("City");
            studentDataTable.Columns.Add("State");
            studentDataTable.Columns.Add("Zip");
            studentDataTable.Columns.Add("Choice1");
            studentDataTable.Columns.Add("CreditHrs1");
            studentDataTable.Columns.Add("Choice2");
            studentDataTable.Columns.Add("CreditHrs2");
            studentDataTable.Columns.Add("Choice3");
            studentDataTable.Columns.Add("CreditHrs3");
            studentDataTable.Columns.Add("Choice4");
            studentDataTable.Columns.Add("CreditHrs4");
            studentDataTable.Columns.Add("Choice5");
            studentDataTable.Columns.Add("CreditHrs5");
            studentDataTable.Columns.Add("Choice6");
            studentDataTable.Columns.Add("CreditHrs6");
            
            // Read in a file line-by-line, and store it
            var txtFileLine = File.ReadAllLines(filePathStudent).ToList();
            //Reads line splits data to colums at tab (ASCII value 9)
            txtFileLine.ForEach(line => studentDataTable.Rows.Add(line.Split((char)9)));
     
            List<int> rowsForColumn1 = studentDataTable.AsEnumerable().Select(x => x.Field<int>(0)).ToList();
            //Tests for empty Datatable
            foreach (DataRow row in studentDataTable.Rows)
            {
                if (row.IsNull("Id"))
                    break;
                else
                    //get max value from "Id" row.
                    maxIDStdTable = rowsForColumn1.Max();
            }
        }
