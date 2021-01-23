    dynamic dynJson = JsonConvert.DeserializeObject(json);
    foreach (var item in dynJson.elements)
    {
        if(item.type==0)
        {
            //Do your specific deserialization here using "item.ToString()"
            //For ex,
            var x = JsonConvert.DeserializeObject<MapElementConferenceRoom>(item.ToString());
        }
    }
