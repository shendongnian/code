	//////////////////////////////////////////////
	//// Setting up the table is as simple as this:	
	DataTable table = new DataTable("fruit");
	
	table.Columns.Add("name", typeof(string) );
	table.Columns.Add("type", typeof(char));
	table.Columns.Add("colour", typeof(string));
	table.Columns.Add("length", typeof(int));
	//////////////  name, type, colour, length
	table.Rows.Add("orange", 'a',"orange", 5);
	table.Rows.Add("apple", 'a',"green", 4);
	table.Rows.Add("banana", 'c',"yellow", 7);
	table.Rows.Add("strawberry", 'b',"red", 3);
	table.Rows.Add("blueberry", 'b',"black", 1);
	table.Rows.Add("gooseberry", 'b',"green", 2);
	//////////////////////////////////////////////
	////// Accessing the data via Linq!
	var results = table.AsEnumerable()
	    .Where(row => row.Field<char>("type") == 'b')
		.OrderBy(row => row.Field<int>("length"))
	    .Select(row => row.Field<string>("name") +": "+row.Field<string>("colour"));				
	foreach(string s in results) Console.WriteLine(s);
	///////////////////////////////
