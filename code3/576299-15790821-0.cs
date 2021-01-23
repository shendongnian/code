      [Serializable] 
      public partial class DB_Image
      {
            public string FullPath { get; set; }
            public string ThumbPath { get; set; }
      }
      [Serializable]
      public class MediaGalleryHolder
      {
           public List<DB_Image> Images { get; set; }
           public List<string> SpinFrames { get; set; }
           public string FlyoverVideo { get; set; }
      }
