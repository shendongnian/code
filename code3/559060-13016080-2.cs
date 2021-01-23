    var englishDic = English.ToDictionary(thing => thing.ID, thing => thing.Stuff);
    var spanishDic = Spanish.ToDictionary(thing => thing.ID, thing => thing.Stuff);
    var germanDic = German.ToDictionary(thing => thing.ID, thing => thing.Stuff);
    
    var query = englishDic.Keys
            .Union(spanishDic.Keys)
            .Union(germanDic.Keys)
            .Select(key => new
            {
                Id = key,
                English = GetValue(englishDic, key),
                Spanish = GetValue(spanishDic, key),
                German = GetValue(germanDic, key),
            });
