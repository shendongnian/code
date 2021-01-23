            var knownIds = new List<string>();
            var jObj = (JObject)JsonConvert.DeserializeObject(json);
            foreach (var doc in jObj["response"])
            {
                var id = (string)doc["id"];
                if (knownIds.Contains(id))
                {
                    doc.Remove();
                }
                else
                {
                    knownIds.Add(id);
                }
            }
