    private void BuildMessage()
    {
        var enum1List = new List<object>();
        FillBits(enum1List);  // => Here I get an error.
    }
    // This method should accept Enum1 and Enum2
    private Byte[] FillBits(IEnumerable<object> enumList)
    {
        foreach (Enum e in enumList)
        {
            int value = Convert.ToInt32(e);
        }
    }
