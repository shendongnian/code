    public IEnumerable<Note> Get(Guid? userId = null, Guid? tagId = null)
    {
        var userNotes = userId.HasValue ? _repository.Get(x => x.UserId == userId.Value) : new List<Note>();
        var tagNotes = tagId.HasValue ? _repository.Get(x => x.TagId == tagId.Value) : new List<Note>();
        return userNotes.Union(tagNotes).Distinct();
    }
