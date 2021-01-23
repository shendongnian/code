        public void ParseFullDataSet(IEnumerable<String> dataSource) {
            var rowCount = dataSource.Count();
            var setCount = Math.Floor(rowCount / 100000) + 1;
            if (rowCount % 100000 != 0)
                setCount++;
            for (int i = 0; i < setCount; i++) {
                var set = dataSource.Skip(i * 100000).Take(100000);
                ParseSet(set);
            }
        }
        public void ParseSet(IEnumerable<String> dataSource) {
            String playerName = String.Empty;
            decimal monetaryValue = 0.0m;
            // Assume here that the method reflects your RegEx generator.
            String regex = RegexFactory.Generate();
            for (String data in dataSource) {
                Match match = Regex.Match(data, regex);
                if (match.Success) {
                    playerName = match.Groups[1].Value;
                    // Might want to add error handling here.
                    monetaryValue = Convert.ToDecimal(match.Groups[2].Value);
                    db.PlayerActions.Add(new PlayerAction() {
                        // ID = ..., // Set at DB layer using Auto_Increment
                        Player_Name = playerName,
                        Monetary_Value = monetaryValue
                    });
                    db.SaveChanges();
                    // If not using Entity Framework, use another method to insert
                    // a row to your database table.
                }
            }
        }
