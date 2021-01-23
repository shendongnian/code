    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication5
    {
        class Program
        {
            public static List<string> SanitiseList(List<string> list)
            {
                List<string> sanitisedList = new List<string>();
                foreach (string filename in list)
                {
                    String sanitisedFilename = String.Empty;
                    if (!String.IsNullOrEmpty(filename))
                    {
                        sanitisedFilename = filename;
                        // get rid of the encoding
                        sanitisedFilename = Uri.UnescapeDataString(sanitisedFilename);
                        // first of all change all back-slahses to forward slashes
                        sanitisedFilename = sanitisedFilename.Replace(@"\", @"/");
                        // if we have two back-slashes at the beginning assume its localhsot
                        if (sanitisedFilename.Substring(0, 2) == "//")
                        {
                            // remove these first double slashes and stick in localhost
                            sanitisedFilename = sanitisedFilename.TrimStart('/');
                            sanitisedFilename = sanitisedFilename = "//localhost" + "/" + sanitisedFilename;
                        }
                        // remove file
                        sanitisedFilename = sanitisedFilename.Replace(@"file://", "//");
                        // remove double back-slashes
                        sanitisedFilename = sanitisedFilename.Replace("\\", @"\");
                        // remove double forward-slashes (but not the first two)
                        sanitisedFilename = sanitisedFilename.Substring(0,2) + sanitisedFilename.Substring(2, sanitisedFilename.Length - 2).Replace("//", @"/");
                    }
                    if (!String.IsNullOrEmpty(sanitisedFilename))
                    {
                        sanitisedList.Add(sanitisedFilename);
                    }
                }
                return sanitisedList;
            }
            static void Main(string[] args)
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                listA.Add("file://localhost//FILE/Musik/BritneySpears.mp3");
                listA.Add("file://localhost//FILE/Musik/30%20Seconds%20To%20Mars.mp3");
                listB.Add("file://localhost//FILE/Musik/120%20Seconds%20To%20Mars.mp3");
                listB.Add(@"\\FILE\Musik\30 Seconds To Mars.mp3");
                listB.Add(@"\\FILE\Musik\5 Seconds To Mars.mp3");
                listA = SanitiseList(listA);
                listB = SanitiseList(listB);
                List<string> missingFromA = listB.Except(listA).ToList();
                List<string> missingFromB = listA.Except(listB).ToList();
            }
        }
    }
