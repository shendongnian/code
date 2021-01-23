    public enum PackageUnitOfMeasurement
    {
            [Description("02")]
            LBS,
            [Description("03")]
            KGS,
    };
    var type = typeof(PackageUnitOfMeasurement);
    var memInfo = type.GetMember(PackageUnitOfMeasurement.LBS.ToString());
    var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
        false);
    var description = ((DescriptionAttribute)attributes[0]).Description;
