    public static class BinaryComparer
    {
     public static int Compare(this Binary v1, Binary v2)
     {
     throw new NotImplementedException();
     }
    }
    var result = from row in MyTable
                 where BinaryComparer.Compare(row.TimeStamp, SomeTarget) > 0
                 select row;
