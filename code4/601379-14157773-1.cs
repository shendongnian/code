    public static void Insert(string name, string validator)
    {
        using (DIEMEntities diemEntities = new DIEMEntities())
        {
            Insert(diemEntities, name, validator);
        }
    }
