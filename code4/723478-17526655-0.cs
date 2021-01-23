    public class Error
    {
        protected int ErrorNo;
    }
    public class ErrorMultiple : Error
    {
        protected List<int> MultipleErrorNos = new List<int>();
    }
    public class Event
    {
        Error errorObject;
        errorObject = new Error();
    public void MultiplyErrors()
    {
        errorObject = new ErrorMultiple();
    }
    }
