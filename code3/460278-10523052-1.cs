    public partial class MessageDataGetdriversRequest : IData<AppDataGetcarsRequest> { }
    public partial class MessageDataGetdriversRequest: IData<AppDataGetdriversRequest> { }
    public static bool IsValid(this IData<T> data)
    {
        return data.AppData != null;
    }
