    private async Task Save(List<Note> notesRepository)
    {
        var jsonSerializer = new DataContractJsonSerializer(typeof (List<Note>));
        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync("notes.json", CreationCollisionOption.ReplaceExisting))
        {
            jsonSerializer.WriteObject(stream, notesRepository);
        }
    }
    private async Task<List<Note>> Load()
    {
        var jsonSerializer = new DataContractJsonSerializer(typeof(List<Note>));
        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("notes.json"))
        {
            return (List<Note>)jsonSerializer.ReadObject(stream);
        }
    }
