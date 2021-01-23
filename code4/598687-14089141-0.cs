    private async Task Save(List<Note> notesRepository)
    {
        var xmlSerializer = new XmlSerializer(typeof (List<Note>));
        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync("notes.xml", CreationCollisionOption.ReplaceExisting))
        {
            xmlSerializer.Serialize(stream, notesRepository);
        }
    }
    private async Task<List<Note>> Load()
    {
        var xmlSerializer = new XmlSerializer(typeof(List<Note>));
        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("notes.xml"))
        {
            return (List<Note>) xmlSerializer.Deserialize(stream);
        }
    }
