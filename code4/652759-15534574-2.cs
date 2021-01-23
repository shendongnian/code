    class commonElements {
       /// some code
    }
    public commoneElements GetCommon(Database1 inDB1) {
       /// some code
    }
    public commoneElements GetCommon(Database2 inDB2) {
       /// some code
    }
    commonElements common;
    if(mode == "PRODUCTION"){
        db1 = new Database1("Connection string for Database1");
        common = GetCommon(db1);
    }
    else{
        db2 = new Database2("Connection string for Database2");
        common = GetCommon(db2);
    }
    
    var result = common.Where(a=>a.Value==1).First();
