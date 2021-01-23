    object obj = yourObject;
    var props = obj.GetType()
                   .GetProperties()
                   .ToDictionary(p => p.Name, p => p.GetValue(obj, null));
    string serializedText = String.Join("\n",
                  props.Select(kv => kv.Key + "=" + kv.Value ?? kv.Value.ToString()));
