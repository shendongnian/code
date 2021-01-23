               var settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Include
            };
            JsonSerializer json = JsonSerializer.Create(settings);
            json.Error += (x, y) =>
            {
                var s = y.ErrorContext;
                var t = y.CurrentObject;
            };
            StringReader sr = new StringReader(jsonString);
            JsonTextReader reader = new JsonTextReader(sr);
           
             
            var o = json.Deserialize<ClsReport>(reader);
            string sf = o.ReportItems[2];
