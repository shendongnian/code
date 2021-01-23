    int option;
    Poll poll = JsonConvert.DeserializeObject<Poll>(json);
    JContainer container = (JContainer)JsonConvert.DeserializeObject(json);
    poll.polloptions = container.Where(t => t as JProperty != null)
        .Cast<JProperty>().Where(p => int.TryParse(p.Name, out option))
        .Select(p => p.Value.Value<string>()).ToList();
