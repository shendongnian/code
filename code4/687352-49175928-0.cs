    string col = "Column3";
    var query = table.Select(i => col == "Column1" ? i.Column1 :
                                  col == "Column2" ? i.Column2 :
                                  col == "Column3" ? i.Column3 :
                                  col == "Column4" ? i.Column4 :
                                  null);
