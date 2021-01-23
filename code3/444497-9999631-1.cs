    public class OpcDotNetTagConverter : StringConverter
        {
            #region Make It A ComboBox
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return false;
            }
            #endregion
    
            #region Display Tags In List
            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                if ((context == null) || (context.Container == null))
                {
                    return null;
                }
                
                Object[] Tags = this.GetTagsFromServer(context);
                if (Tags != null)
                {
                    return new StandardValuesCollection(Tags);
                }
                return null;
            }
    
            private object[] GetTagsFromServer(ITypeDescriptorContext context)
            {
                List<string> availableTags = new List<string>();
    
                if (context.Instance == null)
                {
                    availableTags.Add("ITypeDescriptorContext.Instance is null");
                    return availableTags.ToArray();
                }
    
     
                Interfaces.IOpcDotNetServerEnabled inst = context.Instance as Interfaces.IOpcDotNetServerEnabled;
                if (inst == null)
                {
                    availableTags.Add(context.Instance.ToString());
                    return availableTags.ToArray();
                }
    
                if (inst.OpcDotNetServer == null)
                {
                    availableTags.Add("No server selected");
                    return availableTags.ToArray();
                }
    
                availableTags = inst.OpcDotNetServer.GetTagList(string.Empty);
                availableTags.Sort(Comparer<string>.Default);
                return availableTags.ToArray();
            }
    
            #endregion
    
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if(sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }
    
            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value is string)
                    return value.ToString();
                return base.ConvertFrom(context, culture, value);
            }
    
        }
