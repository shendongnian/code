        public static int GetSequenceNextVal()
        {
            using (YourEntities entities = new YourEntities ())
            {
                var sql = "select myschema.SEQ_STATUS_ID.NEXTVAL from dual";
                var qry = entities.ExecuteStoreQuery<decimal>(sql);
                return (int)qry.First();
            }
        }
