    internal class FilterInfo : IFilterInfo {
      public bool IsPlayable { get; internal set; }
      public bool IsConfigurable { get; internal set; }
    }
    // ...
    private FilterInfo _filterInfo;
    public IFilterInfo FilterInfo {
      get {
        if (_filterInfo == null) {
          // construct FilterInfo the first time around
          _filterInfo = new FilterInfo();
          _filterInfo.IsPlayable = true;
          _filterInfo.IsConfigurable = false;
        }
        return _filterInfo;
      }
    }
