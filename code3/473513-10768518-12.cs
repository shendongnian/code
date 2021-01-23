    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Markup;
    
    namespace WpfApplication
    {
        public class PropertyInfoPathExtension : MarkupExtension
        {
            private readonly PropertyInfo propertyInfo;
    
            public PropertyInfoPathExtension(PropertyInfo propertyInfo)
            {
                if (propertyInfo == null)
                    throw new ArgumentNullException("propertyInfo");
    
                this.propertyInfo = propertyInfo;
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return new PropertyPath(propertyInfo);
            }
        }
    }
