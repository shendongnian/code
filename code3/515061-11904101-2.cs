    public class MyCollectionConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            IEnumerable enumerable = value as IEnumerable;
            if (enumerable == null)
                return base.GetProperties(context, value, attributes);
            int i = 0;
            List<PropertyDescriptor> list = new List<PropertyDescriptor>();
            foreach (object obj in enumerable)
            {
                MyItemPropertyDescriptor index = new MyItemPropertyDescriptor(i.ToString(), obj);
                list.Add(index);
                i++;
            }
            return new PropertyDescriptorCollection(list.ToArray());
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);
            IEnumerable enumerable = value as IEnumerable;
            if (enumerable == null)
                return base.ConvertTo(context, culture, value, destinationType);
            StringBuilder sb = new StringBuilder();
            foreach (object obj in enumerable)
            {
                if (sb.Length > 0)
                {
                    sb.Append(',');
                }
                sb.AppendFormat("{0}", obj);
            }
            return sb.ToString();
        }
    }
