    var uniqueList = dtAllData.AsEnumerable().Select(x=> x.Field<string>("column_1")).Distinct();
    List<string> myList = new List<string>();
    myList =uniqueList.ToList();
    DataTable[] array = new DataTable[myList.Count()];
    int index = 0;
    foreach (string item in myList)
    {
        var Result =  from x in dtAllData.AsEnumerable()
                      where x.Field<string>("column_1") == item
                      select x;
        DataTable table = Result.CopyToDataTable();
        array[index] = table;
        index++;
    }
