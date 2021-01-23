    public override string ToString()
    {
        if (this.count == 0)
        {
            Type t = this.GetType();
    
            if (t.IsGenericType)
            {
                Type g = t.GetGenericTypeDefinition();
    
                return g.Name.Remove(g.Name.IndexOf('`')) + "<" + typeof(T).Name + ">";
            }
    
            return t.ToString();
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                sb.Append(elements[i]);
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
