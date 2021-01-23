    [AttributeUsage(AttributeTargets.Property)]
    class FormattedDoubleFormatString : Attribute
    {
        public string FormatString { get; private set; }
        public FormattedDoubleFormatString(string formatString)
        {
            FormatString = formatString;
        }
    }
