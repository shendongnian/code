    using System.IO;
    using System.ServiceModel;
    namespace Service
    {
        [ServiceContract]
        public interface IStream
        {
            [OperationContract]
            Stream GetLargeObject();
        }
    }
