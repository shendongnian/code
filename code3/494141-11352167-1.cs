        private void button1_Click(object sender, EventArgs e)
        {
            string filename = "c:\\tmp\\test.xls";
            Stopwatch sw1 = Stopwatch.StartNew(); 
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " + 
                                                  "Extended Properties=Excel 12.0", filename);
            using(OleDbConnection cn = new OleDbConnection(connectionString))
            {
                cn.Open();
                using(var adapter = new OleDbDataAdapter("SELECT * FROM [roots$]", cn))
                {
                    var ds = new DataSet();
                    adapter.Fill(ds, "roots");
                    sw1.Stop();
                    Console.WriteLine("Time taken for excel roots: {0} ms", sw1.Elapsed.TotalMilliseconds);
                }
            }
        }
