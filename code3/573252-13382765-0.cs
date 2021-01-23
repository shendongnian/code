    string naValue = null;
    var naRow = table.AsEnumerable().FirstOrDefault(r =>  r.Field<string>("Name") == "NA");
    if(naRow != null)
        naValue = naRow.Field<string>("Value");
    string nbValue = null;
    var nbRow = table.AsEnumerable().FirstOrDefault(r =>  r.Field<string>("Name") == "NB");
    if(nbRow != null)
        nbValue = nbRow.Field<string>("Value");
    NVMapping map = new NVMapping {
        NC = table.AsEnumerable()
            .Where(r => r.Field<string>("Name") == "NC")
            .Select(r => r.Field<string>("Value")).ToList(),
        ND = table.AsEnumerable()
            .Where(r => r.Field<string>("Name") == "ND")
            .Select(r => r.Field<string>("Value")).ToList(),
        NA = naValue,
        NB = nbValue
    };
