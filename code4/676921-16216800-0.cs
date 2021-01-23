    public void FuncSearch_name(string search_name, ref List<T> ListIn, out List<T> ListOut)
    {
        ListOut = ListIn.Where(x => x.Name.Equals(search_name)).ToList();
        ListOut.Sort(this);
    }
