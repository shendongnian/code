    public class Request
    {
        public Request() {
        public MyDataResult DataResult { get; set; }
        public MyDataRequest DataRequest { get; set; }
    }
    MyDataResult dataResult1 = null, dataResult2 = null;
    
    public static void ExecuteRequest(object data)
    {
        Request req = (Request)data;
        req.DataResult = APIManager.ExecuteRequest(req.DataRequest, 
                                          TBIdentifiers.Text, TBCommands.Lines) 
    }
    System.Threading.Thread t1 = new System.Threading.Thread(ExecuteRequest);
    System.Threading.Thread t2 = new System.Threading.Thread(ExecuteRequest);
    t1.Start(new Request{DataResult = dataResult1, DataRequest = dataRequest1});
    t2.Start(new Request{DataResult = dataResult2, DataRequest = dataRequest2});
    t1.Join();
    t2.Join();
