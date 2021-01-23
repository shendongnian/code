    if (Alt.Any(i => i.Item1 == tbAlt.Text))
    {
        Alt.Remove(Alt.First(i => i.Item1 == tbAlt.Text));
        Alt.Add(new Tuple<string, string>(tbAlt.Text, "Something New"));
    }
