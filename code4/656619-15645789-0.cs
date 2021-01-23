            string pattern = @"^GPS:(?<gps>.{8}),N,(?<n>.{10}),WMAG:(\+|\-)(?<wmag>.{3})\\r\\n$";
            string gps = string.Empty;
            string n = string.Empty;
            string wmag = string.Empty;
            string input = @"GPS:050.1347,N,00007.3612,WMAG:+231\r\n";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                Match match = regex.Match(input);
                foreach (Capture capture in match.Groups["gps"].Captures)
                    gps = capture.Value;
                foreach (Capture capture in match.Groups["n"].Captures)
                    n = capture.Value;
                foreach (Capture capture in match.Groups["wmag"].Captures)
                    wmag = capture.Value;
            }
            Console.Write("GPS: ");
            Console.WriteLine(gps);
            Console.Write("N: ");
            Console.WriteLine(n);
            Console.Write("WMAG: ");
            Console.WriteLine(wmag);
            Console.ReadLine();
