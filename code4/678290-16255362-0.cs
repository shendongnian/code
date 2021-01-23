    private void UpdateKey(Dictionary<string,object> dict, string oldKey, string newKey){
        object value;
        if(dict.TryGetValue(oldKey, out value)){
              dict.Remove(oldKey);
              dict.Add(newKey, value);
        }
    }
