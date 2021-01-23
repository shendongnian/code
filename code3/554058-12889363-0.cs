    private readonly string BYTE_ORDER_MARK_UTF8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
    
    ...
    if (line.StartsWith(BYTE_ORDER_MARK_UTF8))
                    line = line.Remove(0, BYTE_ORDER_MARK_UTF8.Length);
