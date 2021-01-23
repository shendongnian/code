csharp
DocumentList = new ReactiveList<Document>() {
    ChangeTrackingEnabled = true,
};
DocumentList.ItemChanged
    .Where(x => x.PropertyName == "IsDirty" && x.Sender.IsDirty)
    .Select(x => x.Sender)
    .Subscribe(x => {
        Console.WriteLine("Make sure to save {0}!", x.DocumentName);
    });
