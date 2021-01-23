                IEnumerable<int> list = OldDic.Keys.Except(NewDic.Keys);
                foreach (var x in list)
                {
                    var value =new MyClass();
                    OldDic.TryGetValue(x,out value );
                    FinalDict.Add(x,value);
                }
