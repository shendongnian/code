    Try This :-
    //My strongly typed dataset
    localData = new LokalStorageDataSet();
    
    //SqlCe-Connection
    localConnection = new SqlCeConnection(@"Data Source=|DataDirectory|\TempStorage.sdf; Password='xyc';Persist Security Info=True");
    
    
    SqlCeCommand command = new SqlCeCommand("SELECT * FROM progstates", localConnection);
    
    localConnection.Open();
    var dataReader = command.ExecuteReader();
    
    localData.Load(dataReader,LoadOption.Upsert,localData.Tables[0]);
    
    localConnection.Close();
 
