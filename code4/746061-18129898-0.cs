    public static T Transform<T>(this object convertFrom) where T : class, new()
            {
                return (T) (new ServiceExtension().Transform(convertFrom, typeof (T)));
                
            }
    private class ServiceExtension
            {
                public object Transform(object convertFrom, Type convertTo)
                {
                    object _t = Activator.CreateInstance(convertTo);
                    if (convertFrom == null) return _t;
    
                    var convertType = convertFrom.GetType();
                foreach (
                    var property in _t.GetType().GetProperties().Where(f => f.CanWrite && f.GetSetMethod(true).IsPublic)
                    )
                {
                    if (property.GetCustomAttributes(typeof (TransformAttribute), true).Any())
                    {
                        var transform =
                            (property.GetCustomAttributes(typeof (TransformAttribute), true).FirstOrDefault() as
                             TransformAttribute);
                        var transformname = transform.RelatedField ?? property.Name;
                        if (convertType.GetProperty(transformname) == null)
                            throw new ArgumentException(
                                string.Format(
                                    "We were unable to find property:\"{0}\" on {1}.  Please check the RelativeField value on the {2} for \"{0}\"",
                                    transformname, convertFrom.GetType().Name, convertTo.Name));
                        var theValue = convertType.GetProperty(transformname).GetValue(convertFrom);
                        if (isCollection(theValue))
                        {
                            foreach (var item in (theValue as ICollection))
                            {
                                var someVal = new object();
                                var newToType = property.PropertyType.GetGenericArguments().FirstOrDefault();
                                if (!String.IsNullOrEmpty(transform.FullyQualifiedName))
                                    someVal =
                                        Transform(
                                            item.GetType().GetProperty(transform.FullyQualifiedName).GetValue(item),
                                            newToType);
                                else
                                    someVal = Transform(item, newToType);
                                if (property.GetValue(_t) == null)
                                    throw new NullReferenceException(
                                        string.Format(
                                            "The following property:{0} is null on {1}.  Likely this needs to be initialized inside of {1}'s empty constructor",
                                            property.Name, _t.GetType().Name));
                                property.PropertyType.GetMethod("Add")
                                        .Invoke(property.GetValue(_t), new[] {someVal});
                                //property.SetValue(_t, theValue.Transform(theValue.GetType()));
                            }
                        }
                        else
                            property.SetValue(_t, theValue);
                    }
                    //property.SetValue(_t, property.GetValue(convertFrom, null), null);
                }
                return _t;
            }
            public bool isCollection(object o)
            {
                return o is ICollection
                       || typeof (ICollection<>).IsInstanceOfType(o);
            }
        }
    public class TransformAttribute : Attribute
        {
            public string RelatedField { get; private set; }
            public string FullyQualifiedName { get; set; }
        public TransformAttribute()
        {
        }
        public TransformAttribute(string relatedField)
        {
            RelatedField = relatedField;
        }
    }
