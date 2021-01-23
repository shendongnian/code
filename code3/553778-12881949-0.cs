    MyClass item = new MyClass() { Name = "aaa" };
    MyClass u = new MyClass() { Name = "uuu", Status = "ssss" };
    MyCopy(item, u);
---
    void MyCopy<T>(T src, T dest)
    {
        var notNullProps = typeof(T).GetProperties()
                                    .Where(x=>x.GetValue(src,null)!=null);
        foreach (var p in notNullProps)
        {
            p.SetValue(dest, p.GetValue(src, null));
        }
    }
