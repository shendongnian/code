     for (int i = 0; i < list.Count; i = i + 5) {
                    var fiveitems = list.Skip(i).Take(5);
                    foreach(var item in fiveitems)
                    {
                    }
                }
