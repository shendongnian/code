    public class PropertyCompareRule : IRule<Request>
    {
        private sealed class PropertyCompare
        {
            public string PropertyName {get; set; }
            public Operand Operand {get; set; }
            public object Value {get; set;}
            public string Reason {get; set; }
        }
        private List<PropertyCompare> _comparers = new List<PropertyCompare>();
        public bool IsValid(Request poco)
        {
            bool isValid = true; // let's be optimistic!
            PropertyInfo[] properties = poco.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where((property) => property.GetIndexParameters().Length == 0 && property.CanRead).ToArray();
            foreach(var property in properties)
            {
                foreach(var comparer in _comparers)
                {
                    bool localIsValid;
                    if(comparer.PropertyName == property.Name)
                    {
                        object val = property.GetValue(poco, null);
                        switch(comparer.Operand)
                        {
                            case Operand.Equals:
                                {
                                    localIsValid = object.Equals(val, property.Value);
                                    break;
                                }
                        }
                        if(!localIsValid)
                        {
                            poco.denyReasons.Add(comparer.Reason);
                            isValid = false;
                        }
                    }
                }
            }
            return isValid;
        }
        public void AddComparer(string propertyName, Operand op, object value, string reason)
        {
            _comparers.Add(new PropertyCompare() { PropertyName = propertyName, Operand = op, Value = value, Reason = reason });
        }
    }
