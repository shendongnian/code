    [Category("Connection")]
    [Description("Specifies the type of connection for this task.")]
    [Editor(typeof(StringEditor), typeof(UITypeEditor))]
    public string TransferProtocol {
      get {
        return stConnectionType;
      }
      set {
        stConnectionType = value;
      }
    }
