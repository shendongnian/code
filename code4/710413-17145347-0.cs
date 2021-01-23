    private void BuildPredicate()
            {
                predicate=(curObj)=>
                {
                    var t = curObj.GetType();
                    var strProps = from p in t.GetProperties() where p.PropertyType == typeof(string) select p;
                    var intProps = from p in t.GetProperties() where p.PropertyType == typeof(int) select p;
    
                    foreach (var str in strProps)
                    {
                        if (str.GetValue(curObj,null) != "X")
                        {
                            return false;
                        }
                    }
                    foreach (var i in intProps)
                    {
                        if ((int)i.GetValue(curObj, null) != 0)
                        {
                            return false;
                        }
                    }
                    return true;
                };
            }
