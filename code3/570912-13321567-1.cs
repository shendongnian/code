    class Vector : Dictionary<string,string>
    {
        public string Get(string Key) //Create a new void Get(string Key) which returns a particular value from a specific Key in the Dictionary (Vector)
        {
            return this[Key]; //Return the key from the Dictionary
        }
        public void add(string Key, string Value) //Create a new void Add(string Key, string Value) which creates a particular value referring to a specific Key in the Dictionary (Vector)
        {
            this.Add(Key, Value); //Add the key and its value to Vector
        }
    }
    Vector property = new Vector(); //Initialize a new class Vector of name property
    property.add("key", "value"); //Sets a key of name "key" and its value "value" of type stirng
    MessageBox.Show(property.Get("key")); //Returns "value"
    //MessageBox.Show(property["key"]); //Returns "value"
