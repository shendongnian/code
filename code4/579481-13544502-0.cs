    interface IAction
    {
      ICommand Command { get; }
      string DisplayText { get; }
      string ToolTipText{ get; }
      URI Icon { get; }
    }
