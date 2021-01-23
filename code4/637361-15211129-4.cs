    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    namespace PropertyGrid_ListBox_Test
    {
        class TypeCodeTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                {
                    return true;
                }
                return base.CanConvertFrom(context, sourceType);
            }
    
            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value is string)
                {
                    List<TypeCodes> list = new List<TypeCodes>();
                    string[] values = ((string)value).Split(new char[] { ';' });
                    foreach (string v in values)
                    {
                        list.Add((TypeCodes)Enum.Parse(typeof(TypeCodes), v));
                    }
    
                    return list;
                }
                return base.ConvertFrom(context, culture, value);
            }
    
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    return true;
                }
                return base.CanConvertTo(context, destinationType);
            }
    
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    List<TypeCodes> list = (List<TypeCodes>)value;
                    string result = "";
                    foreach (TypeCodes type_code in list)
                    {
                        result += Enum.GetName(typeof(TypeCodes), type_code) + "; ";
                    }
                    return result;
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }
