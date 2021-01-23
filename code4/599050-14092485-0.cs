    @foreach(var item in Model.Notes().Where(x => x.TypeId == Note.NoteTypeId))
    {
    }
    
    //and
    
    @foreach(var item in Model.Notes().Where(x => x.TypeId == Note.HistoryTypeId))
    {
    }
    
    public class Note
    {
      public static int HistoryTypeId = 1;
      public static int NoteTypeId = 0;
      /* ... the rest of the implementation */
    }
