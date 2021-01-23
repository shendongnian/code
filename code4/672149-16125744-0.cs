    public class QualityControlStateTypeConverter
                               : TypeConverter<Nullable<byte>, QualityControlState>
    {
        protected override QualityControlState ConvertCore(Nullable<byte> source)
        {
            return (source != null)
                ? (QualityControlState)Enum.Parse(typeof(QualityControlState),
                                                  source.ToString())
                : QualityControlState.Ok;
        }
    }
