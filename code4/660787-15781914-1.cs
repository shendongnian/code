    [DataContract]
    public class PlaylistItem
    {
      // Your composite key...
      [DataMember(Name = "id")]
      public Guid Id { get; set; }    
      public Playlist Playlist { get; set; }
      //  Store Title on PlaylistItem as well as on Video because user might want to rename PlaylistItem.
      [DataMember(Name = "title")]
      public string Title { get; set; }
      // rest of class...
    }
