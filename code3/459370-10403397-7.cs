    private class ExpandoObjectValueAccessor : BaseValueAccessor
        {
            private string memberName;
            public ExpandoObjectValueAccessor(string memberName)
            {
                this.memberName = memberName;
            }
            public override object Get(object context)
            {
                var dictionary = context as IDictionary<string, object>;
                object value;
                if (dictionary.TryGetValue(memberName, out value))
                {
                    return value;
                }
                throw new InvalidPropertyException(typeof(System.Dynamic.ExpandoObject), memberName,
                                                   "'" + memberName +
                                                   "' node cannot be resolved for the specified context [" +
                                                   context + "].");
            }
            public override void Set(object context, object value)
            {
                throw new NotSupportedException("Cannot set the value of an expando object.");
            }
        }
