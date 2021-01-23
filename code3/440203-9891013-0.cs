     static void Main(string[] args)
        {
            var values = new Dictionary<string, object>( );
            values.Add( "name", "timmerz" );
            values.Add( "dob", DateTime.Now );
            values.Add( "sex", "m" );
            SqlUpdate( "sometable", values );
        }
        public static void SqlUpdate( string table, Dictionary<string,object> values, string where )
        {
            var equals      = new List<string>( );
            var parameters  = new List<SqlParameter>( );
            var i = 0;
            foreach( var item in values )
            {
                var pn = "@sp" + i.ToString( );
                equals.Add( string.Format( "{0}={1}", item.Key, pn ) );
                parameters.Add( new SqlParameter( pn, item.Value ) );
                i++;
            }
            string command = string.Format( "update {0} set {1} where {2}", table, string.Join( ", ", equals.ToArray( ) ), where );
            var sqlcommand = new SqlCommand(command);
            sqlcommand.Parameters.AddRange(parameters.ToArray( ) );
            sqlcommand.ExecuteNonQuery( );
        }
