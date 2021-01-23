    public static class CSVParser
    {
        public static void FillPOCO(object poco, string csvData, CSVMapping mapping)
        {
            PropertyInfo[] relevantProperties = poco.GetType().GetProperties().Where(x => mapping.Mapping.Keys.Contains(x)).ToArray();
            string[] dataStrings = csvData.Split(',');
            foreach (PropertyInfo property in relevantProperties)
                SetPropertyValue(poco, property, dataStrings[mapping.Mapping[property.Name]]);
        }
        private static void SetPropertyValue(object poco, PropertyInfo property, string value)
        {
            // .. here goes code to change type to the necessary one ..
            property.SetValue(poco, value);
        }
    }
