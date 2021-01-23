    interface SetData {
      int insertNewAccount(A, B);
    }
    
    interface ModifyData {
      int deleteAccount(A, B);
    }
    
    interface GetData {
      int getAccount(A, B);
    }
    
    class DBHandler : SetData, ModifyData , GetData {
      //
      // Implement the interfaces...
      //
    
      // Returns the interfaces
      SetData setData(){ return (SetData)this; }
      ModifyData modifyData (){ return (ModifyData )this; }
      GetData getData (){ return (GetData )this; }
    }
