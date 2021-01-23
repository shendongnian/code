    if(!context.Recipients.Any(a => Id == recipient.Id))
    {
        context.Recipients.Add(recipient);
    }
    else
    {
        Entity row = context.Recipients.Single(a => a.Id == recipient.Id);
        row.Name = recipient.Name;
    }
    context.SaveChanges();
