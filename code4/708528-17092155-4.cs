    [ServiceContract]
    //[ServiceKnownTypes(typeof(TestGroup))] -- You could also place the attribute here...not sure what the difference is, though.
    public interface ITestGroupService
    {
        [OperationContract]
        [ServiceKnownTypes(typeof(TestGroup))]
        AbstractTestGroup GetTestGroup();
    }
