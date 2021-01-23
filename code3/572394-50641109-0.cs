    public class MustHaveOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var collection = value as IEnumerable;
            if (collection != null && collection.GetEnumerator().MoveNext())
            {
                return true;
            }
            return false;
        }
    }
