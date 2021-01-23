    public void FillArrayList<T>(DataGridView grid, SqlDataReader reader, List<T> list)
    {
        //Fill the list with the contents of the reader
        while (reader.Read())
        {
           Object  obj = new Object();
           Type type = typeof(T); // get the type of T (The paramter you passed in, i.e. Organisations)
           FieldInfo[] fields = type.GetFields(); // Get the fields of the assembly
           int i = 0;
            foreach(var field in fields) // Loop round the fields 
            {
                field.setValue(obj, reader[i]); // set the fields of T to the readers value
                i++;
            }
            list.Add(obj);
        }
    }
