    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        DataSet GetData();
    }
    public class DataService: IDataService
    {
        public DataSet GetData()
        {
            //return some dataset here
        }
    }
