    using System.Text;
    
    ...
    
    public override string ToString()
    {
        StringBuilder s = new StringBuilder("something initial if you need");
        foreach (something item in this)
        {
            s.AppendFormat("Some_Point({0},{1}),", item.X, item.Y);
        }
        s.Append("something else");
    
        return s.ToString();
    }
