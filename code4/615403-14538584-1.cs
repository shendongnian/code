    public class StubSocket
    {
        int MakeRequest(object ServiceId, object Host, object Port, object Request, ref object pResponse)
        {
            pResonse = "Response";
            return 0;
        }
    }
