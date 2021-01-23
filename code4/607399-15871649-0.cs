    Id3v2.Tag tag = (Id3v2.Tag)file.GetTag(TagTypes.Id3v2, false);
    if (tag != null) {
        string track = tag.GetTextAsString(FrameType.TRCK);
        if (track != null) {
            // Do something.
        }
    }
