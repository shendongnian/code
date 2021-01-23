    public class DailyMotionVideo {
      public int page {get;set;}
      public int limit {get;set;}
      public int total {get;set;}
      public bool has_more {get;set;}
      public DailyMotionVideoInternalList[] list {get;set;}
    }
    public class DailyMotionVideoInternalList {
      public string id {get;set;}
      public string title {get;set;}
      public string channel {get;set;}
      public string owner {get;set;}
    }
