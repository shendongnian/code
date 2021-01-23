    private bool VerificarSeExcede(int codProd, int quantItem)
    {
      using(var con = new MySqlConnection(Properties.Settings.Default.ConnectionString)) 
      {
        using(var cmd = new MySqlCommand("SELECT codigo, quantidade FROM tabestoque WHERE codigo = @codProd", con)) 
        {
          cmd.Parameters.Add("@codProd", MySqlDbType.Int32).Value = codProd;
          con.open();
          using(var reader = cmd.ExecuteReader()) 
          {
            if(reader == null) 
               return false;  
            reader.Read();
            var quantDB = reader.GetInt32(1);
            // Verifica se a quantidade do produto no banco de dados é >= que a quantidade do item na lista
            if (quantDB >= quantItem)
              return false;
            else
              return true;
        }
      }
    }
