        public static IEnumerable<JObject> CsvToJson(IEnumerable<string> csvLines)
        {
            var csvLinesList = csvLines.ToList();
            var header = csvLinesList[0].Split(',');
            for (int i = 1; i < csvLinesList.Count; i++)
            {
                var thisLineSplit = csvLinesList[i].Split(',');
                var pairedWithHeader = header.Zip(thisLineSplit, (h, v) => new KeyValuePair<string, string>(h, v));
                yield return new JObject(pairedWithHeader.Select(j => new JProperty(j.Key, j.Value)));
            }
        }
