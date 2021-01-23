    string s = "1588,8DNY;1488,ACNY;1288,7DPE;1888,8HUC;1488,8WNH";
    var OrderedResult= s.Split(';').ToList<string>()
                        .Select(item => item.Split(','))
                        .Select(item => new { price = Int32.Parse(item[0]), code = item[1] })
                        .OrderBy(item => item.price);
    foreach(var item in OrderedResult)
    {
       var sql = "select ..... where price=" + item.price + " and code=" + item.code;
       execute(sql);
    }
