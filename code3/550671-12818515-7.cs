         using (var ctx = new Model()) {
           var firstParam = new Devart.Data.Oracle.OracleParameter("p0", OracleDbType.Number, 1, ParameterDirection.Input);
           var secondParam = new Devart.Data.Oracle.OracleParameter("p1", OracleDbType.Number, ParameterDirection.Output);
           var thirdParam = new Devart.Data.Oracle.OracleParameter("p2", OracleDbType.VarChar, ParameterDirection.Output);
           var resultParam = new Devart.Data.Oracle.OracleParameter("res", OracleDbType.Number, 1, ParameterDirection.Output);
           ctx.Database.ExecuteSqlCommand(@"begin  :res := username_ctx.FUNCTION2(:p0, :p1, :p2);  end;", firstParam, secondParam, thirdParam, resultParam);
           Console.WriteLine("Return value: {0}; int_param: {1}; str_param: '{2}'", resultParam.Value, secondParam.Value, thirdParam.Value);
     } 
