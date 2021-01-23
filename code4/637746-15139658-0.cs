    enum setting {single, multiple, foo, bar};
    Data data = getData(Connection conn, int id);
    var processAll = new Action<Action<item>>(action =>
                        {
                            foreach(var item in data)                           
                                action(item);
                        });
    setting blah = data.getSetting();
    
    switch(blah)
    {
        case blah.single:
           processAll(item => processDataSingle(item, blah));
           break;
           ...
    }
