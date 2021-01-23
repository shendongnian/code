            DataTable CartDT = new DataTable();
            CartDT.Columns.Add("Product_Name", typeof(string));
            CartDT.Columns.Add("Product_ID", typeof(string));
            CartDT.Columns.Add("ItemQTY", typeof(string));
            CartDT.Columns.Add("Price", typeof(string));
            CartDT.Columns.Add("TotalPrice", typeof(string));
            string[] row = new string[5];
            row[0] = "1";  //Product_Name
            row[1] = "2"; //Product_ID
            row[2] = "3"; //OrderQTY
            row[3] = "4"; //Price
            row[4] = "5";// calculate total price 
            CartDT.Rows.Add(row);//Creating row in Datatable using row[] string array
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(CartDT.Rows[0][i]);
            }
            Console.Read();
