    /* $final*/
    IDictionary<Object, Object> final = new Dictionary<Object, Object>();
    /* $final["header"] */
    // by keeping this separated then joining it to final, you avoid having
    // to cast it every time you need to reference it since it's being stored
    // as an Object
    IDictionary<Object, Object> header = new Dictionary<Object, Object> {
        { "title", "Test" },
        { "num", 5 },
        { "limit", 5 }
    };
    // above short-hand declaration is the same as doing:
    // header.Add("title", "Test");
    // header.Add("num", 5);
    // header.Add("limit", 5);
    final.Add("header", header);
    /* $final["data"] */
    IList<Object> data = new List<Object>();
    // not sure where `results` comes from, but I'll assume it's another type of
    // IDictionary<T1,T2>
    foreach (KeyValuePair<Object, Object> kvp in results)
    {
        data.add(new Dictionary<Object, Object> {
            { "primary", "Primary" },
            { "secondary", "Secondary" },
            { "image", "test.png" },
            { "onclick", "alert('You clicked on the Primary');" }
        });
    }
    final.Add("data", data);
