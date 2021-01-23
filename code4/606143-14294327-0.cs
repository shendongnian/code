    ctor()
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        var q = from a in dc.GetTable<Questions>()
                select a;
        _questionEnumerator = q.GetEnumerator();
    }
    void btn_click()
    {
        if (_questionEnumerator.MoveNext())
        {
            var row = _questionEnumerator.Current;
            // do stuff
        }    
    }
