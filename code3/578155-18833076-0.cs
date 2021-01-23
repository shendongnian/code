    JsonConvert.SerializeObject((from a in db.Events where a.Active select a).ToList(), Formatting.Indented,
        new JsonSerializerSettings() {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        }
    );
