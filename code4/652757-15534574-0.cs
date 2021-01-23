    var table;
    
    if(mode == "PRODUCTION"){
        db = new Database1("Connection string for Database1");
        table = db.table1;
    }
    else{
        db = new Database1("Connection string for Database2");
        table = db.table1
    }
    
    var result = table.Where(a=>a.Value==1).First();
