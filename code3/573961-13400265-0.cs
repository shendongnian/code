    public interface IUndoable 
    { 
       void Undo(); 
    }
    public interface IVeryUndoable 
    { 
       void Undo(); 
    }
    
    public class TextBox : IUndoable, IVeryUndoable
    {
         void IUndoable.Undo() { Console.WriteLine ("TextBox.Undo"); }
         void IVeryUndoable.Undo() { Console.WriteLine ("TextBox.VeryUndo"); }
    }
