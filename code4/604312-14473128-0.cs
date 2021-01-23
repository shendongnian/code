    class SetForeignKeyColumn : IAutomappingOverride<FirstClass>
    {
        public ...
        {
            instance.HasMany(x => x.AnotherClassList).KeyColumn("baseclass_id");
        }
    }
