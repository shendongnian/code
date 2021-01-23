        [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDuplexCallback))]
    public interface IDuplexService
    {
        [OperationContract(IsOneWay = true)]
        void FormatString(string institution);
    }
