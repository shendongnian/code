    DataAdapter myAdapter = new DataAdapter()
    
    myAdapter.SelectCommand = new OleDbCommand();
    myAdapter.InsertCommand = new OleDbCommand();
    myAdapter.UpdateCommand = new OleDbCommand();
    myAdapter.DeleteCommand = new OleDbCommand();
    
    myAdapter.SelectCommand.CommandText = "select * from MyTable where MyID = ?";
    myAdapter.InsertCommand.CommandText = "insert into MyTable ( ColX, ColY, ColZ ) values ( ?, ?, ? )";
    myAdapter.UpdateCommand.CommandText = "update MyTable set ColX = ?, ColY = ?, ColZ = ? where MyID = ?";
    myAdapter.DeleteCommand.CommandText = "delete from MyTable where MyID = ?";
