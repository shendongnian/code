    XElement select = new XElement("select");
    XElement optGroup = null;
    foreach (var topic in topics)
    {
        // skip root topic
        if (!topic.Item1.EndsWith("0000"))
        {
            // optgroup
            if (topic.Item1.EndsWith("00"))
            {
                optGroup = new XElement("optgroup", new XAttribute("label", topic.Item2));
                select.Add(optGroup);
            }
            // option
            else if (optGroup != null)
            {
                optGroup.Add(new XElement("option", new XAttribute("value", topic.Item1), new XText(topic.Item2)));
            }
        }
    }
    Console.WriteLine(select);
