    private Task ProcessButton(Deelnemer deelnemer)
    {
       string id = deelnemer.DeelnemerVoornaam + " " + deelnemer.DeelnemerNaam;
       deelnemersTimer[id] = await CheckButtons(clients[id]);
    
       // is this the first one?
       if (eerste == null)
           eerste = id;
    }
    …
    var tasks = deelnemers.Select(ProcessButton);
    await Task.WhenAll(tasks);
