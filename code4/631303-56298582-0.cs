    public interface ISqlFunctions
    {
        [System.Data.Entity.Core.Objects.DataClasses.EdmFunction("SqlServer", "STR")]
        string StringConvert(Decimal? number);
    }
