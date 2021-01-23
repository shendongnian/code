    signaller.RaiseSaveRequest(pluginStates);  <----has all plugin's packedState
    //loop through plugins to get values and types
    Dictionary<string, object> dictProjectState = new Dictionary<string, object>();
      
    foreach (KeyValuePair<string,IDictionary<string,object>> plugin in pluginStates)
    { 
        //holds jsonRepresented values
        Dictionary<string, object> dictJsonRep = new Dictionary<string, object>(); 
        //holds object types
        Dictionary<string, object> dictObjRep = new Dictionary<string, object>(); 
        object[] arrayDictHolder = new object[2];  //holds all of the dictionaries
        
        string pluginKey = plugin.Key;
        
        IDictionary<string, object> pluginValue = new Dictionary<string, object>(); 
        pluginValue = plugin.Value;
                
        foreach (KeyValuePair<string, object> element in pluginValue)
        {
          string jsonRepresentation = JsonConvert.SerializeObject(element.Value);
          object objType = element.Value.GetType();
          dictJsonRep.Add(element.Key, jsonRepresentation);
          dictObjRep.Add(element.Key, objType);
        }
        arrayDictHolder[0] = dictJsonRep;
        arrayDictHolder[1] = dictObjRep;
        dictProjectState.Add(pluginKey, arrayDictHolder);
    }
          
    JsonSerializer serializer = new JsonSerializer();
    using (StreamWriter sw = new StreamWriter(strPathName))
    using (JsonWriter writer = new JsonTextWriter(sw))
    {
        serializer.Serialize(writer, dictProjectState);
    }
