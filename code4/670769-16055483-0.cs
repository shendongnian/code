    private void BuildMessage()
    {
        List<Enum1> Enum1List = new List<Enum1>();
        Enum1List.Add(Enum1.Fire);
        Enum1List.Add(Enum1.Follower);
        FillBits(Enum1List);
    }
    private Byte[] FillBits<T>(List<T> enumList)
    {
        foreach (var e in enumList)
        {
            int value = Convert.ToInt32(e);
        }
    }
