    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Lastfm.Services;
    
    namespace AddTags {
    
        /// <summary>
        /// Class made for scanning a folder and giving al mp3's moar tags
        /// </summary>
        internal class Program {
    
            public static void Main(string[] args) {
                Session session = new Session("94b659f1b129a3f110a0faa269b4be68", "649461398a675e38870c07b1614085e4");
    
                // Authenticate it with a username and password to be able
                // to perform write operations and access this user's profile
                // private data.
                session.Authenticate("cskiwi", Lastfm.Utilities.md5("Cskiwi147963"));
    
                DirectoryInfo dir = new DirectoryInfo("C:\\Users\\kiwi\\Dropbox\\music\\Mk3");
                Console.WriteLine("Setting genretags for directory: " + dir.FullName);
                foreach (FileInfo file in dir.GetFiles("*.*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".mp3") || file.Extension.Equals(".wav"))) {
                    Console.WriteLine();
                    Console.WriteLine(" --- " + file.Name + " ---");
                    TagLib.File TagFile = TagLib.File.Create(file.FullName);
    
                    // Create an Artist object.
                    if (TagFile.Tag.Performers.Length > 0) {
                        Artist artist = new Artist(TagFile.Tag.Performers[0], session);
    
                        // Display your current tags for system of a down.
                        List<string> tags = new List<string>();
                        try {
                            foreach (TopTag tag in artist.GetTopTags(20))
                                tags.Add(tag.Item.Name.ToString());
                            if (tags.Count == 0)
                                Console.WriteLine("No tags found");
                        } catch (Exception e) {
                            Console.WriteLine("Artist not found");
                        }
    
                        TagFile.Tag.Genres = tags.ToArray();
                        TagFile.Save();
    
                        foreach (string tag in TagFile.Tag.Genres) {
                            Console.Write(" " + tag);
                        }
                    } else {
                        Console.WriteLine("No artist found in tags");
                    }
                    Console.WriteLine();
                }
    
                Console.Write("press any key to exit");
                Console.ReadLine();
            }
        }
    }
