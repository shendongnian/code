    public sealed class Settings
    {
      private static readonly Lazy<Settings> _instance = new Lazy<Settings>(() => new Settings());
      private Dictionary<string, object> m_lProperties = new Dictionary<string, object>();
      private List<AppSetting> mySettings = new List<AppSetting>();
