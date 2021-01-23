    public class SettingsNode<TSetting, TChild, TSibbling>
    {
        public Setting<TSetting> Setting { get; set; }
        public Setting<TChild> Child { get; set; }
        public Setting<TSibbling> Sibling { get; set; }
    }
    public class Setting<T>
    {
        public T Value;
    }
    SettingsNode<String, int, int> node = new SettingsNode<string, int, int>();
    node.Sibling = new Setting<int>();
    node.Setting = new Setting<string>();
    node.Child = new Setting<int>();
