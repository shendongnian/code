    public static class DropDownData
    {
        // struct, IComparable, IFormattable, IConvertible is as close as we'll 
        // get to an Enum constraint. We don't actually use the constraint for 
        // anything except rudimentary compile-time type checking, though, so 
        // you may leave them out.
        public static EnumDataItemList GetList<T>() 
                where T : struct, IComparable, IFormattable, IConvertible
        {
            // Just to make the intent explicit. Enum.GetValues will do the
            // type check, if this is left out:
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type must be an enumeration");
            }
            EnumDataItemList items = new EnumDataItemList();
            foreach (Enum e in Enum.GetValues(typeof(T)))
            {
                EnumDataItem items = new EnumDataItem();
                // Note: This assumes the enum's underlying type is
                // assignable to Int32 (for example, not a long):
                int value = Convert.ToInt32(e);
                // The same attribute retrieval code as in the 
                // WeekDays example, including:
                item.Text = e.ToString(); // e is Enum here, no need for GetName
            }
        }
    }
