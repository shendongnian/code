    class MyCustomSqlGenerator : IPersistentIdentifierGenerator
    {
        private SqlString _sql = new SqlString("your select here");
        public string GeneratorKey()
        {
            return _sql.ToString();
        }
        public string[] SqlCreateStrings(Dialect dialect)
        {
            // TODO: return sql Create of sqlfunction
        }
        public string[] SqlDropString(Dialect dialect)
        {
            // TODO: return sql DROP of sqlfunction
        }
        public object Generate(ISessionImplementor session, object obj)
        {
            try
            {
                IDbCommand cmd = session.Batcher.PrepareCommand(CommandType.Text, _sql, SqlTypeFactory.NoTypes);
                IDataReader reader = null;
                try
                {
                    reader = session.Batcher.ExecuteReader(cmd);
                    try
                    {
                        reader.Read();
                        object result = IdentifierGeneratorFactory.Get(reader, NHibernateUtil.String, session);
                        return result;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    session.Batcher.CloseCommand(cmd, reader);
                }
            }
            catch (DbException sqle)
            {
                throw ADOExceptionHelper.Convert(session.Factory.SQLExceptionConverter, sqle, "could not get next sequence value");
            }
        }
    }
