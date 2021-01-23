    var list = new List<ArraySegment<byte>>();
    list.Add(new ArraySegment<byte>(lTxBytes));
    list.Add(new ArraySegment<byte>(Encoding.ASCII.GetBytes(lTx.Identity)));
    list.Add(new ArraySegment<byte>(Encoding.ASCII.GetBytes(lResponse)));
    e.BufferList = list;
