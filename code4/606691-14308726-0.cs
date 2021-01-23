    string[] mp3Files = Directory.GetFiles(_mp3Directory, "*.mp3");
    
                InfoProvider chartLyricsProvider = new ChartLyricsInfoProvider();
                InfoProvider lyrDbLyricsProvider = new LyrDbInfoProvider();
                foreach (string mp3File in mp3Files)
                {
                    Console.Write(Path.GetFileNameWithoutExtension(mp3File));
    
                    Id3Tag tag;
                    using (var mp3 = new Mp3File(mp3File))
                        tag = mp3.GetTag(Id3TagFamily.FileStartTag);
                    if (tag == null)
                        continue;
    
                    if (!tag.Artists.IsAssigned || !tag.Title.IsAssigned)
                    {
                        Console.WriteLine();
                        continue;
                    }
    
                    Console.WriteLine(" ({0} - {1})", tag.Artists.Values[0], tag.Title.Value);
    
                    Id3Tag[] lyricsTags = GetLyrics(tag, chartLyricsProvider, lyrDbLyricsProvider);
                    if (lyricsTags == null || lyricsTags.Length == 0)
                        continue;
    
                    string outputFilename = string.Format("{0} - {1}.txt", tag.Artists.Values[0], tag.Title.Value);
                    string outputFile = Path.Combine(_outputDirectory, outputFilename);
                    using (var lyricsWriter = new StreamWriter(outputFile, false))
                        lyricsWriter.Write(lyricsTags[0].Lyrics[0].Lyrics);
    
                    Console.WriteLine("    {0}", outputFilename);
                }
