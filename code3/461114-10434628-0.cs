    public class MyResponse<T>
    {
       public MyResult<T> Result{ get; set; }
       public MyResponseHeader ResponseHeader { get; set; }
    }
    public class MyResult<T>
    {
       public T[] DocumentList{ get; set; }
       public int NumRecords{ get; set; }
       public int Start{ get; set; }
    }
