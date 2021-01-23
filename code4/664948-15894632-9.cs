    internal class FilterInfo : IFilterInfo {
      public bool IsPlayable { get; internal set; }
      public bool IsConfigurable { get; internal set; }
    }
    public IFilterInfo GetFilterInfo() {
      return new FilterInfo() { IsPlayable = true, IsConfigurable = false };
    }
