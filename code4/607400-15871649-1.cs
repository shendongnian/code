    Id3v2.Tag tag = (Id3v2.Tag)file.GetTag(TagTypes.Id3v2, false);
    if (tag != null) {
        TextInformationFrame trackFrame = TextInformationFrame.Get (tag, FrameType.TRCK, false);
        if (trackFrame != null) {
            string [] text = trackFrame.Text;
            
            // Do something.
        }
    }
