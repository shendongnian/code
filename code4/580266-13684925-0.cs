    var listA = from o in context where (...) select o;
    foreach (var i in listA)
                {
                    if (!i.Bs.IsLoaded)
                        i.Bs.Load();
                    if (i.Bs != null)
                    {
                        if (!i.Bs.Cs.IsLoaded)
                            i.Bs.Cs.Load();
                    }
                    
                }
