    public class EnumConversion
    {
        internal static EnumDst FromSrcToDst(ResolutionContext arg)
        {
            EnumSrc value = (EnumSrc)arg.SourceValue;
            switch(value)
            {
                case EnumSrc.Option1:
                    return EnumDst.Choice1;
                case EnumSrc.Option2:
                    return EnumDst.Choice2;
                case EnumSrc.Option3:
                    return EnumDst.Choice3;
                default:
                    return EnumDst.None;
            }
        }
    }
