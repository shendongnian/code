    //store all the values that will not change through the execution for faster access
    var productNameInfoRows = dsProductNameInfo.Tables[0].Rows;
    var fullRows = dsFull.Tables[0].Rows;
    var productInfoCount = productNameInfoRows.Count;
    var fullCount = fullRows.Count;
    
    //Create a list of the words from the product info
    var lists = new Dictionary<int, Tuple<List<int>, List<int>>>(productInfoCount*3);
    for(var i = 0;i<productInfoCount;i++){
        foreach (var token in productNameInfoRows[i][0].ToString().Split(';')
                              .Select(p => p.GetHashCode())){
            if (!lists.ContainsKey(token)){
                lists.Add(token, Tuple.Create(new List<int>(), new List<int>()));
            }
            lists[token].Item1.Add(i);
        }
    }
    //Pair words from full with those from productinfo
    for(var i = 0;i<fullCount;i++){
        foreach (var token in fullRows[i][0].ToString().Split(';')
                              .Select(p => p.GetHashCode())){
            if (lists.ContainsKey(token)){
                lists[token].Item2.Add(i);
            }
        }
    }
    
    //Count all matches for each pair of rows
    var counts = new Dictionary<int, Dictionary<int, int>>();
    foreach(var key in lists.Keys){
        foreach(var p in lists[key].Item1){
            if(!counts.ContainsKey(p)){
                counts.Add(p,new Dictionary<int, int>());
            }
            foreach(var f in lists[key].Item2){
                var dic = counts[p];
                if(!dic.ContainsKey(f)){
                    dic.Add(f,0);
                }
                dic[f]++;
            }
        }
    }
