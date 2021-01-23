     public static void DeleteLine(string kv) {
          OleDbConnection myConnection = GetConnection();
          string myQuery = "DELETE FROM Cloth WHERE [ClothName] = '" + kv + "'" ;
     }
           
