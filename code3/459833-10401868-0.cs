        public virtual void SetDifferences(MyBaseClass compareTo)
        {
            var differences = this.GetDifferentProperties(compareTo);
            differences.ToList().ForEach(x =>
            {
                x.SetValue(this, x.GetValue(compareTo, null), null);
            });
        }
        public virtual IEnumerable<PropertyInfo> GetDifferentProperties(MyBaseClass compareTo)
        {
            var signatureProperties = this.GetType().GetProperties();
            return (from property in signatureProperties
                    let valueOfThisObject = property.GetValue(this, null)
                    let valueToCompareTo = property.GetValue(compareTo, null)
                    where valueOfThisObject != null || valueToCompareTo != null
                    where (valueOfThisObject == null ^ valueToCompareTo == null) || (!valueOfThisObject.Equals(valueToCompareTo))
                    select property);
        }
