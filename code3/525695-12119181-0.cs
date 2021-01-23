    public interface IFilter<T>
    {
        T Value { get; set; }
        String Operator { get; set; }
        Boolean IncludeOperator { get; set; }
    }
    public abstract class Filter<T> : IFilter<T>
    {
        T _value;
        String _operator = "=";
        Boolean _includeOperator = false;
        public T Value { get { return this._value; } set { this._value = value; } }
        public String Operator { get { return this._operator; } set { this._operator = value; } }
        public Boolean IncludeOperator { get { return this._includeOperator; } set { this._includeOperator = value; } }
        public override string ToString()
        {
            String param = GetValueAsString();
            if (param != null && this.IncludeOperator)
                return this.Operator + " " + param;
            else if (param != null && !this.IncludeOperator)
                return param.Trim();
            else
                return null;
        }
        protected abstract String GetValueAsString();
    }
    public class IntFilter : Filter<Nullable<Int64>>
    {
        protected override string GetValueAsString()
        {
            // Convert the integer to a string
            return this.Value.HasValue ? this.Value.ToString() : "0";
        }
    }
    public class BooleanFilter : Filter<Nullable<Boolean>>
    {
        protected override string GetValueAsString()
        {
            // convert the Boolean to a BIT value 1=True / 0=False
            return (this.Value.HasValue && this.Value.Value) ? "1" : "0";
        }
    }
    public class DateTimeFilter : Filter<Nullable<DateTime>>
    {
        protected override string GetValueAsString()
        {
            // Convert the DateTime to a dateTime string in the following format - 2/27/2009 12:12:22 PM
            return (this.Value.HasValue) ? this.Value.Value.ToString("G") : null;
        }
    }
    public class StringFilter : Filter<String>
    {
        protected override string GetValueAsString()
        {
            return string.IsNullOrWhiteSpace(Value) ? "" : Value;
        }
    }
