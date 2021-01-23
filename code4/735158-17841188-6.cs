    // Represents a value provider for the data in an uploaded CSV file.
    public class CSVValueProvider : IValueProvider
    {
        private CSVReader _csvReader;
        
        public CSVValueProvider(ControllerContext controllerContext, CSVReader csvReader)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (csvReader == null)
            {
                throw new ArgumentNullException("csvReader");
            }
            _csvReader = csvReader;
        }
        public bool ContainsPrefix(string prefix)
        {
            if (prefix.Contains('[') && prefix.Contains(']'))
            {
                if (prefix.Contains('.'))
                {
                    var header = prefix.Split('.').Last();
                    if (_csvReader.GetColumnIndex(header) == -1)
                    {
                        return false;
                    }
                }
                int index = int.Parse(prefix.Split('[').Last().Split(']').First());
                if (index >= _csvReader.RowCount)
                {
                    return false;
                }
            }
            return true;
        }
        public ValueProviderResult GetValue(string key)
        {
            if (!key.Contains('[') || !key.Contains(']') || !key.Contains('.'))
            {
                return null;
            }
            object value = null;
            var header = key.Split('.').Last();
            int index = int.Parse(key.Split('[').Last().Split(']').First());
            value = _csvReader.GetValue(header, index);
            if (value == null)
            {
                return null;
            }
            return new ValueProviderResult(value, value.ToString(), CultureInfo.CurrentCulture);
        }
    }
