            using (var sr = new StreamReader(f))
            {
                // retrieves just the name of the file
                // after a few tests, it seems to be faster
                // than instantiating a FileInfo, not a big deal though
                var outfilename = f.Split('\\').Last();
                // reads the first line from the source file
                string line = sr.ReadLine();
                // run the expression to match the values
                // we want to separate
                var match = firstLineParser.Match(line);
                // now that we have the groups, we can format
                // the values the way we want
                line = String.Format("{0} {1} {2}"
                    , match.Groups["StationName"].Value
                    , match.Groups["Lat"].Value.Replace(" ", ".")
                    , match.Groups["Long"].Value.Replace(" ", ".")
                );
