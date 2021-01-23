    private static T CastTo<T>(this Object x, T targetType)
    {
        return (T)x;
    }
    ...
    var tmp = new { AA = 0, Description = "", Shop = "", Price = 0.0}
    tmp = l1.Items.GetItemAt(0).CastTo(tmp);
    string price= "Price = " + tmp.Price;
