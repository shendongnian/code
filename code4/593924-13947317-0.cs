    foreach (var item in findResults)
    {
        emailInformations.Add(new ExchangeEmailInformation ...);
        // start new task
        Task.Factory.Start(() => {
            AddAttachment(item.Subject, item.docId, item.User ...);
        })
    }
