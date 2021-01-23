    public class XmlArtistsConcept
    {
        public void Run()
        {
            XDocument artistDocument = XDocument.Load(@"http://musicbrainz.org/ws/2/release-group?query=the%20heist");
            XNamespace artistNamespace = @"http://musicbrainz.org/ns/mmd-2.0#";
            // The purpose of this query is to demonstrate getting this for a particular result.                
            var theHeistNames =
                string.Join(", ",
                    artistDocument
                    .Element(artistNamespace + "metadata")
                    .Element(artistNamespace + "release-group-list")
                    .Elements(artistNamespace + "release-group")
                    .Where(element => element.Attribute("id").Value == "22315cdd-4ed9-427c-9492-560cf4afed58").Single()
                    .Elements(artistNamespace + "artist-credit")
                    .Elements(artistNamespace + "name-credit")
                    .Elements(artistNamespace + "artist")
                    .Select(artist => artist.Element(artistNamespace + "name").Value).ToArray());
    
            Console.WriteLine(theHeistNames);
            // This query will get it for everything in the XDocument. I made a quick data bucket to dump the values in.
            var allAlbumResults =
                artistDocument
                .Element(artistNamespace + "metadata")
                .Element(artistNamespace + "release-group-list")
                .Elements(artistNamespace + "release-group")
                .Where(releaseGroup => releaseGroup.Attribute("type") != null)
                .Select(releaseGroup =>
                {
                    return new AlbumResult()
                    {
                        Title = releaseGroup.Element(artistNamespace + "title").Value,
                        Artist = string.Join(", ",
                                        releaseGroup
                                        .Elements(artistNamespace + "artist-credit")
                                        .Elements(artistNamespace + "name-credit")
                                        .Elements(artistNamespace + "artist")
                                        .Select(artist => artist.Element(artistNamespace + "name").Value)
                                        .ToArray()),
                        Type = releaseGroup.Attribute("type").Value,
                    };
                });
    
            allAlbumResults.ToList().ForEach(albumResult => Console.WriteLine("Title: {0}, Artist: {1}, Type: {2}", albumResult.Title, albumResult.Artist, albumResult.Type));
            Console.WriteLine();
            Console.WriteLine("Finished");
        }
    }
    
    public class AlbumResult
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Type { get; set; }
    }
