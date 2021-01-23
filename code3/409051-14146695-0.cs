    public sealed class Bar
    {
        public void Foo(string json)
        {
            if (!String.IsNullOrEmpty(json))
            {
                var jobj = JsonObject.Parse(json);
                var barVal = jobj.GetNamedNumber("bar");
                // if all went well, barVal should be a double value of 
                // the number passed in the object (19.0 based on the original question).
            }                 
        }
    }
