    public interface IRecord 
    {
        void RecordFunc();
    } 
    public class ARecord : IRecord
    {
        public void RecordFunc()
        {
            Console.WriteLine("ARecord.RecordFunc");
        }
    }
    public class AnotherRecord : IRecord
    {
        public void RecordFunc()
        {
            Console.WriteLine("AnotherRecord.RecordFunc");
        }
    }
    public class CustomPanel : Panel
    {    
        private IRecord _parentRecord;
        // Where parentRecord could be ARecord or AnotherRecord
        public class CustomPanel(IRecord parentRecord)
        {
            _parentRecord = parentRecord;
        }
        public void MyFunc(object sender, EventArgs e)
        {
            _parentRecord.RecordFunc();
        }
    }
