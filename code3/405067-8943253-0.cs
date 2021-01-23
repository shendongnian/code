    class Derived : Base
    {
        protected override string GetFormattedAttribute(string propertyName,
                                                        object propertyValue)
        {
            var list = propertyValue as List<Contact>;
            if(list == null)
                return base.GetFormattedAttribute(propertyName, propertyValue);
            else
                return GetFormattedAttribute(propertyName, list);
        }
        protected string GetFormattedAttribute(string propertyName,
                                               List<Contact> contacts)
        {
            // ...
        }
    }
