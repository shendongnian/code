            string input = "AT+CMGL=\"ALL\" +CMGL: 0,\"REC READ\",\"+40728072005\",,\"12/06/29,13:04:26+12\" password,1,ON";
            var result = Regex.Match(
                input,
                @"^[^,]*,[^,]*,\""(?<msisdn>[^,]*)\"",.*,\""(?<date>\d{2}\/\d{2}/\d{2},\d{2}:\d{2}:\d{2}\+\d{2})\""\s(?<passwd>[^,]*),(?<itemno>[^,]*),(?<command>.*)$"
                );
            Console.WriteLine(result.Groups["msisdn"].Value);
            Console.WriteLine(result.Groups["date"].Value);
            Console.WriteLine(result.Groups["passwd"].Value);
            Console.WriteLine(result.Groups["itemno"].Value);
            Console.WriteLine(result.Groups["command"].Value);
            Console.ReadKey();
