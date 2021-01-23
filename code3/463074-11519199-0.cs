    public class VSUndo : IDisposable
    {
        public static UndoContext undoContext;
        public static VSUndo StartUndo()
        {
            undoContext = ((DTE2)Package.GetGlobalService(typeof(DTE))).UndoContext; 
            undoContext.Open(Guid.NewGuid().ToString());
            // return new instance for calling dispose to close current undocontext
            return new VSUndo(); 
        }
        public void Dispose()
        {
            undoContext.Close();
        }
    }
