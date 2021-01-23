     public program()
            {
                //Establishing the connection.
                DBOperations _DBOperations = new DBOperations();
                _DBOperations.ConnectDB();
    
                //Update the datebase
                _DBOperations.UpdateDB();                           //Update the database but it doesn't commit the changes.                       
    
                //Issue Rollback to rollback the transaction.
                _DBOperations.RollbackTransaction();                //Successfully Rollbacks the database changes.
    
    
                _DBOperations.ConnectDB(); //you need to assign new tranjection because your last transaction is  over when you commit or roll back 
                _DBOperations.UpdateDB();                           //Update the database it commits the changes. 
    
                //Issue Rollback to rollback the transaction.
                _DBOperations.RollbackTransaction();                //Rollback fails.
    
            }
        }
