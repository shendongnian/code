    public void Mph(int _mph)
    {
        CreateSortedList(v => v.Mph <= _mph);
    }
    public void Brand(string _brand)
    {
        CreateSortedList(v => v.Brand == _brand);
    }
