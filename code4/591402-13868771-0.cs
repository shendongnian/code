	/* Get an array of Types for each of your columns.
	 * Open the data file for reading.
	 * Create your DataTable and add the columns.
	 * (You have already done all of these in your earlier processing.)
	 * 
	 * Note:	For the sake of generality, I've used an IEnumerable<string> 
	 * to represent the lines in the file, although for large files,
	 * you would use a FileStream or TextReader etc.
	*/		
	IList<Type> columnTypes;		//array or list of the Type to use for each column
	IEnumerable<string> fileLines;	//the lines to parse from the file.
	DataTable table;				//the table you'll add the rows to
	int colCount = columnTypes.Count;
	var typeCodes = new TypeCode[colCount];
	var converters = new TypeConverter[colCount];
	//Fill up the typeCodes array with the Type.GetTypeCode() of each column type.
	//If the TypeCode is Object, then get a custom converter for that column.
	for(int i = 0; i < colCount; i++) {
		typeCodes[i] = Type.GetTypeCode(columnTypes[i]);
		if (typeCodes[i] == TypeCode.Object)
			converters[i] = TypeDescriptor.GetConverter(columnTypes[i]);
	}
	//Probably faster to build up an array of objects and insert them into the row all at once.
	object[] vals = new object[colCount];
	object val;
	foreach(string line in fileLines) {
		//delineate the line into columns, however you see fit. I'll assume a tab character.
		var columns = line.Split('\t');
		for(int i = 0; i < colCount) {
			switch(typeCodes[i]) {
				case TypeCode.String:
					val = columns[i]; break;
				case TypeCode.Int32:
					val = int.Parse(columns[i]); break;
				case TypeCode.DateTime:
					val = DateTime.Parse(columns[i]); break;
				//...list types that you expect to encounter often.
				//finally, deal with other objects
				case TypeCode.Object:
				default:
					val = converters[i].ConvertFromString(columns[i]);
					break;
			}
			vals[i] = val;
		}
		//Add all values to the row at one time. 
		//This might be faster than adding each column one at a time.
		//There are two ways to do this:
		var row = table.Rows.Add(vals); //create new row on the fly.
		// OR 
		row.ItemArray = vals; //(e.g. allows setting existing row, created previously)
	}
