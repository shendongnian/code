    int i = 0;
    var qc = QueryComplete[3];
    qc[i++] = Query.EQ("color", "red");
    qc[i++] = Query.EQ("size", "large");
    qc[i++] = Query.GT("cost", 3);
    var query = Query.And(qc);
