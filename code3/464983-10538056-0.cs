            var splitString = "username=bill&password=pass";
            var splits = new char[2];
            splits[0] = '=';
            splits[1] = '&';
            var items = splitString.Split(splits);
            var list = new Dictionary<string, string> {{items[1], items[3]}};
            var username = list.First().Key;
            var password = list.First().Value;
