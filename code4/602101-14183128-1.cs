Doing that with C# classes might help structure the problem into smaller parts and getter better maintainable solution. However surely that's also possible with a DataTable. Another disadvantage of data tables is that the data is not easily being implemented typesafe. In the first version of this answer the casts of r["criterionPMD"] to string was missing so there was a reference comparison instead of string comparison.
            //create the workings out datatable and fill it
            DataTable dtWorkings = new DataTable();
            dtWorkings.Columns.Add("unitNo", typeof(int));
            dtWorkings.Columns.Add("unitName", typeof(string));
            dtWorkings.Columns.Add("criterionPMD", typeof(string));
            dtWorkings.Columns.Add("passFail", typeof(int));
            dtWorkings.Rows.Add(2, "Computer systems", "P", 3);
            dtWorkings.Rows.Add(2, "Computer systems", "P", 2);
            dtWorkings.Rows.Add(3, "Web rubbish", "P", 3);
            // create the results datatable
            DataTable dtResults = new DataTable();
            dtResults.Columns.Add("units", typeof(int));
            dtResults.Columns.Add("name", typeof(string));
            dtResults.Columns.Add("P", typeof(bool));
            dtResults.Columns.Add("M", typeof(bool));
            dtResults.Columns.Add("D", typeof(bool));
            dtResults.Columns.Add("points", typeof(int));
            //fill the results table
            foreach (var units in dtWorkings.Rows.Cast<DataRow>().GroupBy(r => r["unitNo"]))
            {
                var p = units.Where(r => (string)r["criterionPMD"] == "P").All(r => (int)r["passFail"] == 3);
                var m = units.Where(r => (string)r["criterionPMD"] == "M").All(r => (int)r["passFail"] == 3);
                var d = units.Where(r => (string)r["criterionPMD"] == "D").All(r => (int)r["passFail"] == 3);
                dtResults.Rows.Add(
                     units.Key,//UnitNo
                     units.Select(r => r["unitName"]).First(),//UnitName                    
                     p,
                     m,
                     d,
                     p ? (m ? (d ? 90 : 80) : 70) : 0);//Points
            }
