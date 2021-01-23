    IDataLayer db_layer = XpoDefault.GetDataLayer(new SqlConnection(@sqlCon_str),
        DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
        Session session =new Session(db_layer);
    
    mypersistent record =new mypersistent(session){
    property1="string property",
    property2=123456
    };
    record.Save(); // save new record(line) to Database With Unique Oid
    
