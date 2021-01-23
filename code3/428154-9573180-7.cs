    var musicInfo = new MusicInfo
    {
         Name = "Prince Charming",
         Artist = "Metallica",
         Genre = "Rock and Metal",
         Album = "Reload",
         AlbumImage = "http://up203.siz.co.il/up2/u2zzzw4mjayz.png",
         Link = "http://f2h.co.il\/7779182246886"
    };
    
    // This will produce a JSON String
    var serialized = JSONSerializer<MusicInfo>.Serialize(musicInfo);
    
    // This will produce a copy of the instance you created earlier
    var deserialized = JSONSerializer<MusicInfo>.DeSerialize(serialized);
