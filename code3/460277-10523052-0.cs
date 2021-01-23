    public IData<TRequest>  {
        T AppData { get; set; }
        bool IsValid { get; }
    }
    public partial class MessageDataGetdriversRequest : IData<AppDataGetcarsRequest>
    {
        bool IsValid { get { this.AppData != null; } }
    }
    public partial class MessageDataGetdriversRequest: IData<AppDataGetdriversRequest>
    {
        bool IsValid { get { this.AppData != null; } }
    }
