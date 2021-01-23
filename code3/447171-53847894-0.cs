    public object tst() {
        var a = new {
            prop1 = "test1",
            prop2 = "test2"
        };
    
        return a;
    }
    public string tst2(object anonymousObject, string propName) {
        return anonymousObject.GetType().GetProperties()
            .Where(w => w.Name == propName)
            .Select(s => s.GetValue(anonymousObject))
            .FirstOrDefault().ToString();
    }
