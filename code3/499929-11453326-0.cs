    public abstract class WebResourceBase {
      public ResourceBase LocalPath { get; set; }
      public ResourceBase FtpPath { get; set; }
      protected abstract ResourceBase ConvertFromString(string path);
      public string LocalPathStr { set { LocalPath = ConvertFromString(value); } }
      public string FtpPathStr { set { FtpPath = ConvertFromString(value); } }
    }
