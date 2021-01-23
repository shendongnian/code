    public IEnumerable<FieldDefApplied> FieldDefsAppliedSearch
    {
        get
        {
            return fieldDefsApplied.Where(df => df.FieldDef.DispSearch).OrderBy(df => df.FieldDef.DispName);
        }
    }
