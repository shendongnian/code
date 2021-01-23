    public class GetVendors(string filePath, string appName)
    {
    var _sessionManager = new QBSessionManager();
    _sessionManager.CommunicateOutOfProcess(true);
    _sessionManager.OpenConnection2(string.Empty, appName, ENConnectionType.ctLocalQBD);
    _sessionManager.BeginSession(filePath, ENOpenMode.omDontCare);
    _request = _sessionManager.CreateMsgSetRequest("US", 12, 0);
    _request.AppendVendorQueryRq();
    //do somethign to filter your vendor query here.
    var response = _sessionManager.DoRequests(_request);
    var vendorList = (ICheckRetList)response.ResponseList.GetAt(0).Detail;
    }
