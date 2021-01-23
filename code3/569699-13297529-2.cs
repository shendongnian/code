    Poll poll = JsonConvert.DeserializeObject<Poll>(json);
    JContainer container = (JContainer)JsonConvert.DeserializeObject(json);
    var pollOptionNames = container.Where(t => t as JProperty != null)
        .Cast<JProperty>().Where(p => int.TryParse(p.Name, out option))
        .Select(p => int.Parse(p.Name)).ToList();
    var pollOptionValues = container.Where(t => t as JProperty != null)
        .Cast<JProperty>().Where(p => int.TryParse(p.Name, out option))
        .Select(p => p.Value.Value<string>()).ToList();
    poll.polloptions = pollOptionNames.Select((n, i) =>
        new PollOption() { Name = n, Value = pollOptionValues[i] }).ToList();
