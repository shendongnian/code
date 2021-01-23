       using (var ctx = new Model()) {
           var firstParam = new Devart.Data.Oracle.OracleParameter("p0", OracleDbType.Number, 1, ParameterDirection.Input);
           var secondParam = new Devart.Data.Oracle.OracleParameter("p1", OracleDbType.Number, ParameterDirection.Output);
           var thirdParam = new Devart.Data.Oracle.OracleParameter("p2", OracleDbType.VarChar, ParameterDirection.Output);
           var cursorParam = new Devart.Data.Oracle.OracleParameter("cursor_param", OracleDbType.Cursor, ParameterDirection.Output);
           var result = ctx.Database.SqlQuery<int>(
    		@"declare
    			 res number;  
    		begin
    			 res := username_ctx.FUNCTION2(:p0, :p1, :p2);
    			 open :cursor_param for select res from dual;
    		end;",  firstParam, secondParam, thirdParam, cursorParam).FirstOrDefault();
           Console.WriteLine("Return value: {0}; int_param: {1}; str_param: '{2}'", result, secondParam.Value, thirdParam.Value);
          }
 
