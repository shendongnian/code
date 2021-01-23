    internal class VatLevelConvertor : ITypeConverter<EnumType1.VatLevel, EnumType2.VatRateLevel>
    {
        public EnumType2.VatRateLevel Convert(ResolutionContext context)
        {
            EnumType1.VatLevel value = (EnumType1.VatLevel)context.SourceValue;
            switch (value)
            {
                case EnumType1.VatLevel.Standard:
                    return EnumType2.VatRateLevel.Normal;
                case EnumType1.VatLevel.Reduced:
                    return EnumType2.VatRateLevel.Lower;
                case EnumType1.VatLevel.SuperReduced:
                    return EnumType2.VatRateLevel.Other;
                default:
                    return EnumType2.VatRateLevel.Other;
            }
        }
    }
