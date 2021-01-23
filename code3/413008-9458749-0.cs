    [ComVisible(true)]
    public interface IComRfcTable
    {
        public void DoSomething();
    }
    [ComVisible(true)]
    public class ComRfcTable
    {
        private _rfcTable; // object to wrap
        public ComRfcTable(IRfcTable rfcTable)
        {
            _rfcTable = rfcTable
        }
        public void DoSomething()
        {
            _rfcTable.DoSomething();
        }
    }
