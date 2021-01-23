    @foreach(var note in Model.Notes().Where(x => x.IsHistoric))
    {
    }
    
    // and
    
    @foreach(var note in Model.Notes().Where(x => !x.IsHistoric())
    {
    }
