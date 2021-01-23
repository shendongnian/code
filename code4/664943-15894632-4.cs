    public class FilterInfo {
      public bool IsConfigurable { get; private set; }
      public bool IsPlayable { get; private set; } 
    
      public FilterInfo(bool isConfigurable, bool isPlayable /* etc. */) {
        this.IsConfigurable = isConfigurable;
        this.IsPlayable = isPlayable;
      }
    }
