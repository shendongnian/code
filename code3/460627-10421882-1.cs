    Contents.Add("a string", "string value");
    Contents.Add("an integer", 1);
    Contents.Add("a nullable integer", new Nullable<int>(2));
    // Get objects as the type we originally used.
    Debug.WriteLine(string.Format("GetValue<string>(\"a string\") = {0}", GetValue<string>("a string")));
    Debug.WriteLine(string.Format("GetValue<int>(\"an integer\") = {0}", GetValue<int>("an integer")));
    Debug.WriteLine(string.Format("GetValue<int?>(\"a nullable integer\") = {0}", GetValue<int?>("a nullable integer")));
    // Get objects as base class object.
    Debug.WriteLine(string.Format("GetValue<object>(\"a string\") = {0}", GetValue<object>("a string")));
    Debug.WriteLine(string.Format("GetValue<object>(\"an integer\") = {0}", GetValue<object>("an integer")));
    Debug.WriteLine(string.Format("GetValue<object>(\"a nullable integer\") = {0}", GetValue<object>("a nullable integer")));
    // Get the ints as the other type.
    Debug.WriteLine(string.Format("GetValue<int?>(\"an integer\") = {0}", GetValue<int?>("an integer")));
    Debug.WriteLine(string.Format("GetValue<int>(\"a nullable integer\") = {0}", GetValue<int>("a nullable integer")));
    // Attempt to get as a struct that it's not, should return default value.
    Debug.WriteLine(string.Format("GetValue<double>(\"a string\") = {0}", GetValue<double>("a string")));
    // Attempt to get as a nullable struct that it's not, or as a class that it's not, should return null.
    Debug.WriteLine(string.Format("GetValue<double?>(\"a string\") = {0}", GetValue<double?>("a string")));
    Debug.WriteLine(string.Format("GetValue<StringBuilder>(\"a string\") = {0}", GetValue<StringBuilder>("a string")));
