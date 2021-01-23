    abstract class PluginEngineBase<T>
       where T: PluginSettingsBase
    {
       public abstract T Settings { get; set; }
    }
