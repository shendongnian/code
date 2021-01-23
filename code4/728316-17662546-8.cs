    static void InitializeData3(IList objects, PropertyInfo[] props, List<Dictionary<string, object>> tod) {
        foreach(Obj item in objects) {
            var kvp = new Dictionary<string, object>();
            foreach(var p in props) {
                kvp.Add(p.Name, returnProps(p.Name, item));
            }
            tod.Add(kvp);
        }
    }
    static object returnProps(string propName, Obj curObject) {
        if(propName == "p00") {
            return curObject.p00;
        }
        else if(propName == "p01") {
            return curObject.p01;
        }
        else if(propName == "p02") {
            return curObject.p02;
        }
        else if(propName == "p03") {
            return curObject.p03;
        }
        else if(propName == "p04") {
            return curObject.p04;
        }
        else if(propName == "p05") {
            return curObject.p05;
        }
        else if(propName == "p06") {
            return curObject.p06;
        }
        else if(propName == "p07") {
            return curObject.p07;
        }
        else if(propName == "p08") {
            return curObject.p08;
        }
        else if(propName == "p09") {
            return curObject.p09;
        }
        else if(propName == "p10") {
            return curObject.p10;
        }
        else if(propName == "p11") {
            return curObject.p11;
        }
        else if(propName == "p12") {
            return curObject.p12;
        }
        else if(propName == "p13") {
            return curObject.p13;
        }
    
        return new object();
    }
