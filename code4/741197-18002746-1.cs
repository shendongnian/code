    public class GroupHeaderTypeConverter : StringConverter
    {
        private static List<String> groupHeaderList = new List<String>();
        public override Boolean GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override Boolean GetStandardValuesExclusive(ITypeDescriptorContext context) { return false; }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) { return new StandardValuesCollection(groupHeaderList); }
        public static void SetList(List<String> newList) { groupHeaderList = newList; }
    }
