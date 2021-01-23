    var glossaryEntry = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(json);
    var keys = glossaryEntry.Keys.ToList();
    var scoring1 = glossaryEntry["Scoring"];
    //OR
    var scoring2 = glossaryEntry[keys[0]];
