    IDictionary<string, IDictionary<string, object>> pluginStates = new Dictionary<string, IDictionary<string, object>>();
                       
    StreamReader sr = new StreamReader(fullName);
    JsonTextReader reader = new JsonTextReader(sr);
    string json = sr.ReadToEnd();
    var dictProjectState = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    sr.Close();
    reader.Close();
            
    foreach (var projectStatePair in dictProjectState)
    {
        string pluginKey = projectStatePair.Key; //key in pluginStates dict
        Dictionary<string, object> dictJsonRep = new Dictionary<string, object>();
        Dictionary<string, object> dictObjRep = new Dictionary<string, object>();
        Dictionary<string, object> pluginValues = new Dictionary<string, object>();
        string stpluginValue = projectStatePair.Value.ToString();
               
        Newtonsoft.Json.Linq.JArray ja = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(stpluginValue);
        object[] arrayHolder = ja.ToObject<object[]>();
        string strArray0 = arrayHolder[0].ToString();
        string strArray1 = arrayHolder[1].ToString();
        dictJsonRep = JsonConvert.DeserializeObject<Dictionary<string, object>>(strArray0);
        dictObjRep = JsonConvert.DeserializeObject<Dictionary<string, object>>(strArray1);
        foreach (var pair in dictJsonRep)
        {
             string strVariableKey = pair.Key;
             object objType = dictObjRep[pair.Key];
             string jsonRep = (string)pair.Value;
             Type jsonType = Type.GetType(objType as string);
             object jsonReprValue = null;
             jsonReprValue = JsonConvert.DeserializeObject(jsonRep, jsonType);
             pluginValues.Add(strVariableKey, jsonReprValue);
        }
        pluginStates.Add(pluginKey, pluginValues);
    }
         
    signaller.UnpackProjectState(pluginStates);
