        public bool CanLock(int spvId)
        {
            SqlParameter parameter = new SqlParameter("spvId", SqlDbType.Int);
            parameter.Value = spvId;
            ExecuteProcedure("Exec prc_SitePartVrsn_CanLock {0}", parameter);
            return false;
        }
