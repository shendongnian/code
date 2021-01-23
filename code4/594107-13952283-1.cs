    var mailItems = findResults.Where(x => x is EmailMessage).Cast<EmailMessage>().ToList();
    foreach (EmailMessage item in mailItems)
    {
         Console.WriteLine(item.From.Address);
    }
