            string input = "AT+CMGL=\"ALL\"\n+CMGL: 0,\"REC READ\",\"+40728072005\",,\"12/06/29,13:04:26+12\"\npassword,1,ON";
            var matches = Regex.Matches(
                input,
                @"\""(?<msisdn>\+\d*)\"",.*,\""(?<date>\d{2}\/\d{2}/\d{2},\d{2}:\d{2}:\d{2}\+\d{2})\"".*\n+(?<passwd>[^,]*),(?<itemno>\d*),(?<command>\w*)"
                , RegexOptions.Singleline);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.Groups["msisdn"].Value);
                Console.WriteLine(m.Groups["date"].Value);
                Console.WriteLine(m.Groups["passwd"].Value);
                Console.WriteLine(m.Groups["itemno"].Value);
                Console.WriteLine(m.Groups["command"].Value);
            }
            Console.ReadKey();
