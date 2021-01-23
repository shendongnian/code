    class ViewModel
    {
         public object Obj { get { return CurrentRow[CurrentAccessor]; } }
         public Row CurrentRow{ get; }
         public Accessor CurrentAccessor { get; }
    }
