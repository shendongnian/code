    using (MyContext container = new myContext())
    {
        Sale result = container
            .Sales
            .Include("Products")
            .Where(s => s.Id == id)
            .FirstOrDefault();
        return result;
    }
