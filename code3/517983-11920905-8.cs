    class Program
    {
        public static System.Data.DataSet dataSet;
        public static System.Data.DataSet dataSet2;
        public static System.Data.DataSet dataSet3;
        public static System.Data.DataSet dataSet4;
        public static Random rand = new Random();
        public static int NumOfRows = 300000;
        static void Main(string[] args)
        {
            #region test1
            Console.WriteLine("Starting");
            Console.WriteLine("");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            MakeTable();
            watch.Stop();
            Console.WriteLine("Elapsed Time was: " + watch.ElapsedMilliseconds + " milliseconds.");
            dataSet = null;
            Console.WriteLine("");
            Console.WriteLine("Completed.");
            Console.WriteLine("");
            #endregion
            /*
            #region test2
            Console.WriteLine("Starting Test 2");
            Console.WriteLine("");
            watch.Reset();
            watch.Start();
            MakeTable2();
            watch.Stop();
            Console.WriteLine("Elapsed Time was: " + watch.ElapsedMilliseconds + " milliseconds.");
            dataSet2 = null;
            Console.WriteLine("");
            Console.WriteLine("Completed Test 2.");
            #endregion
            #region test3
            Console.WriteLine("");
            Console.WriteLine("Starting Test 3");
            Console.WriteLine("");
            watch.Reset();
            watch.Start();
            MakeTable3();
            watch.Stop();
            Console.WriteLine("Elapsed Time was: " + watch.ElapsedMilliseconds + " milliseconds.");
            dataSet3 = null;
            Console.WriteLine("");
            Console.WriteLine("Completed Test 3.");
            
            #endregion
             */ 
             
            #region test4
            Console.WriteLine("Starting Test 4");
            Console.WriteLine("");
            watch.Reset();
            watch.Start();
            MakeTable4();
            watch.Stop();
            Console.WriteLine("Elapsed Time was: " + watch.ElapsedMilliseconds + " milliseconds.");
            dataSet4 = null;
            Console.WriteLine("");
            Console.WriteLine("Completed Test 4.");
            #endregion
            //printTable();
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
        private static void MakeTable()
        {
            DataTable table = new DataTable("Table 1");
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            table.Columns.Add(column);
            for (int i = 65; i <= 90; i++)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "5-Letter Word " + (char)i;
                column.AutoIncrement = false;
                column.Caption = "Random Word " + (char)i;
                column.ReadOnly = false;
                column.Unique = false;
                // Add the column to the table.
                table.Columns.Add(column);
            }
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i < NumOfRows; i++)
            {
                row = table.NewRow();
                row["id"] = i;
                for (int j = 65; j <= 90; j++)
                {
                    row["5-Letter Word " + (char)j] = getRandomWord();
                }
                table.Rows.Add(row);
            }
        }
        private static void MakeTable2()
        {
            DataTable table = new DataTable("Table 2");
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            table.Columns.Add(column);
            for (int i = 65; i <= 90; i++)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "5-Letter Word " + (char)i;
                column.AutoIncrement = false;
                column.Caption = "Random Word " + (char)i;
                column.ReadOnly = false;
                column.Unique = false;
                // Add the column to the table.
                table.Columns.Add(column);
            }
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            dataSet2 = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet2.Tables.Add(table);
            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i < NumOfRows; i++)
            {
                row = table.NewRow();
                row.BeginEdit();
                row["id"] = i;
                for (int j = 65; j <= 90; j++)
                {
                    row["5-Letter Word " + (char)j] = getRandomWord();
                }
                row.EndEdit();
                table.Rows.Add(row);
            }
        }
        private static void MakeTable3()
        {
            DataTable table = new DataTable("Table 3");
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            table.Columns.Add(column);
            for (int i = 65; i <= 90; i++)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "5-Letter Word " + (char)i;
                column.AutoIncrement = false;
                column.Caption = "Random Word " + (char)i;
                column.ReadOnly = false;
                column.Unique = false;
                // Add the column to the table.
                table.Columns.Add(column);
            }
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            dataSet3 = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet3.Tables.Add(table);
            DataRow[] newRows = new DataRow[NumOfRows];
            for (int i = 0; i < NumOfRows; i++)
            {
                newRows[i] = table.NewRow();
            }
            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i < NumOfRows; i++)
            {
                newRows[i]["id"] = i;
                for (int j = 65; j <= 90; j++)
                {
                    newRows[i]["5-Letter Word " + (char)j] = getRandomWord();
                }
                table.Rows.Add(newRows[i]);
            }
        }
        private static void MakeTable4()
        {
            DataTable table = new DataTable("Table 2");
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            table.Columns.Add(column);
            for (int i = 65; i <= 90; i++)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "5-Letter Word " + (char)i;
                column.AutoIncrement = false;
                column.Caption = "Random Word " + (char)i;
                column.ReadOnly = false;
                column.Unique = false;
                // Add the column to the table.
                table.Columns.Add(column);
            }
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            dataSet4 = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet4.Tables.Add(table);
            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i < NumOfRows; i++)
            {
                table.Rows.Add( 
                    
                    new Object[] {
                
                        i,
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord(),
                        getRandomWord()
                    } 
                
                );
            }
        }
        private static string getRandomWord()
        {
            char c0 = (char)rand.Next(65, 90);
            char c1 = (char)rand.Next(65, 90);
            char c2 = (char)rand.Next(65, 90);
            char c3 = (char)rand.Next(65, 90);
            char c4 = (char)rand.Next(65, 90);
            return "" + c0 + c1 + c2 + c3 + c4;
        }
        private static void printTable()
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine( row["id"] + "--" + row["5-Letter Word A"] + " - " + row["5-Letter Word Z"] );
            }
        }
    }
