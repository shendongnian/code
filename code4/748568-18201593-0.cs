    string artistName = mov.get_Annotation((int)QTAnnotationsEnum.qtAnnotationArtist);
    string albumName = mov.get_Annotation((int)QTAnnotationsEnum.qtAnnotationAlbum);
    string songTitle = mov.get_Annotation((int)QTAnnotationsEnum.qtAnnotationFullName);
    artistName = RemoveSymbols(artistName);
    albumName = RemoveSymbols(albumName);
    ...
    private static string RemoveSymbols(string input)
    {
        if (input == null)
        {
            return input;
        }
        return input.Replace("?", "")
                    .Replace("*", "")
                    .Replace("/", "")
                    .Replace(":", "");
    }
