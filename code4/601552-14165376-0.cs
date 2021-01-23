    public interface IHaveCustomDisplayFormatProperties
    {
    }
    public class TestAttribute : IHaveCustomDisplayFormatProperties
    {
        [CustomDisplayFormatAttribute(DataFormatString = "{0}")]
        public int MyInt { get; set; }
        [CustomDisplayFormatAttribute(DataFormatString = "{0:0.000}")]
        public float MyFloat { get; set; }
        [CustomDisplayFormatAttribute(DataFormatString = "{0:0.0}")]
        public float MyFloat2 { get; set; }
        [CustomDisplayFormatAttribute(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MyDateTime { get; set; }
    }
    public static class IHaveCustomDisplayFormatPropertiesExtensions
    {
        public static string FormatProperty<T, U>(this T me, Expression<Func<T, U>> property)
            where T : IHaveCustomDisplayFormatProperties
        {
            return null; //TODO: implement
        }
    }
