public class PostOBjectBase
{
        /// <summary>
        /// Returns a List of List<string> - one for each object that is going to be parsed.
        /// </summary>
        /// <param name="entryListString">Raw query string</param>
        /// <param name="firstPropertyNameOfObjectToParseTo">The first property name of the object that is sent in the list (unless otherwise specified).  Used as a key to start a new object string list.  Ex: "id", etc.</param>
        /// <returns></returns>
        public List<List<string>> GetQueryObjectsAsStringLists(string entryListString, string firstPropertyNameOfObjectToParseTo = null)
        {
            // Decode the query string (if necessary)
            string raw = System.Net.WebUtility.UrlDecode(entryListString);
            // Split the raw query string into it's data types and values
            string[] entriesRaw = raw.Split('&');
            // Set the first property name if it is not provided
            if (firstPropertyNameOfObjectToParseTo == null)
                firstPropertyNameOfObjectToParseTo = entriesRaw[0].Split("=").First();
            // Create a list from the raw query array (more easily manipulable) for me at least
            List<string> rawList = new List<string>(entriesRaw);
            // Initialize List of string lists to return - one list = one object
            List<List<string>> entriesList = new List<List<string>>();
            // Initialize List for current item to be added to in foreach loop
            bool isFirstItem = false;
            List<string> currentItem = new List<string>();
            // Iterate through each item keying off of the firstPropertyName of the object we will ultimately parse to
            foreach (string entry in rawList)
            {
                if (entry.Contains(firstPropertyNameOfObjectToParseTo + "="))
                {
                    // The first item needs to be noted in the beginning and not added to the list since it is not complete
                    if (isFirstItem == false)
                    {
                        isFirstItem = true;
                    }
                    // Finished getting the first object - we're on the next ones in the list
                    else
                    {
                        entriesList.Add(currentItem);
                        currentItem = new List<string>();
                    }
                }
                currentItem.Add(entry);
            }
            // Add the last current item since we could not in the foreach loop
            entriesList.Add(currentItem);
            return entriesList;
        }
        public T GetFromQueryString<T>(List<string> queryObject) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();
            foreach (string entry in queryObject)
            {
                string[] entryData = entry.Split("=");
                foreach (var property in properties)
                {
                    if (entryData[0].Contains(property.Name))
                    {
                        var value = Parse(entryData[1], property.PropertyType);
                        if (value == null)
                            continue;
                        property.SetValue(obj, value, null);
                    }
                }
            }
            return obj;
        }
        public object Parse(string valueToConvert, Type dataType)
        {
            if (valueToConvert == "undefined" || valueToConvert == "null")
                valueToConvert = null;
            TypeConverter obj = TypeDescriptor.GetConverter(dataType);
            object value = obj.ConvertFromString(null, CultureInfo.InvariantCulture, valueToConvert);
            return value;
        }
}
Then you can inherit from this class in wrapper classes for POST requests and parse to whichever objects you need.  In this case, the code parses a list of objects passed as a query string to a list of wrapper class objects.
For example:
public class SampleWrapperClass : PostOBjectBase
{
    public string rawQueryString { get; set; }
    public List<ObjectToParseTo> entryList
    {
        get
        {
            List<List<string>> entriesList = GetQueryObjectsAsStringLists(rawQueryString);
            List<ObjectToParseTo> entriesFormatted = new List<ObjectToParseTo>();
            foreach (List<string> currentObject in entriesList)
            {
                ObjectToParseToentryPost = GetFromQueryString<ObjectToParseTo>(currentObject);
                entriesFormatted.Add(entryPost);
            }
                
            return entriesFormatted;
        }
    }
}
