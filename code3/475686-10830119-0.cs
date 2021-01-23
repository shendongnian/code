            Dictionary<string, VisitsSummaryResult> myObjList = new Dictionary<string, VisitsSummaryResult>();
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(e.Result);
            
            foreach (KeyValuePair<string, object> pair in values)
            {
                try
                {
                    myObjList.Add(pair.Key, JsonConvert.DeserializeObject<VisitsSummaryResult>(pair.Value.ToString())); // Getting the raw, inner Json string
                }
                catch (Exception ex)
                {
                    myObjList.Add(pair.Key, null); // Exception: insert null
                }
            }
