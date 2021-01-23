    public interface ISupportAggregate
    {
        object[] Individuals { get; }
    }
    public class AggregateTypeConverter : TypeConverter
    {
        public const string MULTIPLE = @"[multiple]";
        private TypeConverter mTypeConverter;
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            Initialize(context);
            if (context != null && destinationType == typeof(string))
            {
                var aggregate = context.Instance as ISupportAggregate;
                if (aggregate != null && IsDifferingItems(context.PropertyDescriptor.Name, aggregate.Individuals))
                {
                    return MULTIPLE;
                }
            }
            return mTypeConverter.ConvertTo(context, culture, value, destinationType);
        }
        public static bool IsDifferingItems(string propertyName, object[] items)
        {
            PropertyDescriptor itemProperty = TypeDescriptor.GetProperties(items[0].GetType())[propertyName];
            return items.Select(itemProperty.GetValue).Distinct().Count() > 1;
        }
        private void Initialize(ITypeDescriptorContext context)
        {
            if (mTypeConverter == null)
                mTypeConverter = TypeDescriptor.GetConverter(context.PropertyDescriptor.PropertyType);
        }
        #region Calling through to mTypeConverter
        public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        {
            Initialize(context);
            return mTypeConverter.CreateInstance(context, propertyValues);
        }
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            Initialize(context);
            return mTypeConverter.GetCreateInstanceSupported(context);
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            Initialize(context);
            return mTypeConverter.GetProperties(context, value, attributes);
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            Initialize(context);
            return mTypeConverter.GetPropertiesSupported(context);
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            Initialize(context);
            return mTypeConverter.GetStandardValues(context);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            Initialize(context);
            return mTypeConverter.GetStandardValuesExclusive(context);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            Initialize(context);
            return mTypeConverter.GetStandardValuesSupported(context);
        }
        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            Initialize(context);
            return mTypeConverter.IsValid(context, value);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            Initialize(context);
            return mTypeConverter.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            Initialize(context);
            return mTypeConverter.ConvertFrom(context, culture, value);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            Initialize(context);
            return mTypeConverter.CanConvertTo(context, destinationType);
        }
        #endregion
    }
    public class AggregateTestClass : TestClass
    {
        private readonly TestClass[] mObjects;
        public AggregateTestClass(TestClass[] objects)
        {
            mObjects = objects;
        }
        protected override object[] GetIndividuals()
        {
            return mObjects;
        }
    }
	
	public class TestClass : ISupportAggregate
	{
	    [TypeConverter(typeof(AggregateTypeConverter))]
	    public int IntProperty { get; set; }
        [TypeConverter(typeof(AggregateTypeConverter))]
		public string StringProperty { get; set; }
		
        [BrowsableAttribute(false)]
        public object[] Individuals
        {
            get { return GetIndividuals(); }
        }
        virtual protected object[] GetIndividuals()
        {
            return new[] { this };
        }
	}
	public class TestSupportAggregate : ISupportAggregate, TestClass
	{
		private readonly TestClass[] mItems;
		public TestSupportAggregate(TestClass[] items)
		{
			mItems = items;
		}
		public object[] Individuals
		{
			get { return mItems; }
		}
	}
	
    To use in code:
	
    control.SelectedObject = new TestSupportAggregate(new[]
													 {
														 new TestClass { IntProperty = 5150 },
														 new TestClass { IntProperty = 1984 }
													 });
	
