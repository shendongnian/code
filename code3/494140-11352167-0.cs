    // test.xls contains 26664 rows by 5 columns. Average 10 char for column, file size is 2448kb
    // OS Windows 7 Ultimate 64 bit. CPU Intel Core2 Quad Q9550 2.83ghz 
    // 8gb ram and disk C is an 256gb SSD cruzer
        private void button1_Click(object sender, EventArgs e)
        {
            string filename = "c:\\tmp\\test.xls";
            Stopwatch sw1 = Stopwatch.StartNew(); 
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " + 
                                                  "Extended Properties=Excel 12.0", filename);
            using(var adapter = new OleDbDataAdapter("SELECT * FROM [roots$]", connectionString))
            {
                var ds = new DataSet();
                adapter.Fill(ds, "roots");
                sw1.Stop();
                Console.WriteLine("Time taken for excel roots: {0} ms", sw1.Elapsed.TotalMilliseconds);
            }
        }
