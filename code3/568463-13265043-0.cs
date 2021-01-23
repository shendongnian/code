    var identityMap = new Dictionary<int, object_a>();
    var data = Query<object_a, table_c, object_a>(sql, (a, c) => {
        object_a master;
        if(!identityMap.TryGetValue(a.ta_id, out master)) {
            identityMap[a.ta_id] = master = a;
        }
        var list = (List<table_c>)master.SomeName;
        if(list == null) {
            master.SomeName = list = new List<table_c>();
        }
        list.Add(c);
        return master;
    }, ...).Distinct().ToList();
