    public static class Mapping
    {
        public static void Init()
        {
            Mapper.CreateMap<IDataReader, Dest>()
                .ForMember(s => s.IsFoo, opt => opt.ReadAsBoolean("IsFoo"))
                .ForMember(s => s.Quux, opt => opt.ReadAsNumber("Quux"));
            Mapper.AssertConfigurationIsValid();
        }
        public static void ReadAsBoolean(this IMemberConfigurationExpression<IDataReader> opt, string fieldName)
        {
            opt.MapFrom(reader => reader.GetString(reader.GetOrdinal(fieldName)).ToUpper() == "Y");
        }
        public static void ReadAsNumber(this IMemberConfigurationExpression<IDataReader> opt, string fieldName)
        {
            opt.MapFrom(reader => reader.GetDecimal(reader.GetOrdinal(fieldName)));
        }
    }
