    public ISINameMasterRecord FindIDCriteria(int id)
            {
                ICriteria criteria = this.CreateCriteria();
                criteria.Add(Expression.Eq("NM_ID_NUM", id));
                
                return criteria.UniqueResult<ISINameMasterRecord>();
            }
