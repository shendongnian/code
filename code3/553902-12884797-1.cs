    public class MyObject
    {
        public const int ARRAY_LENGTH = 3;
        public int[] Ints = new int[ARRAY_LENGTH]
    }
    public abstract class UndoRedoAction
    {
        private MyObject myobj;
        private int oldValues = new int[MyObject.ARRAY_LENGTH];
        private int newValues = new int[MyObject.ARRAY_LENGTH];
        
        public UndoRedoAction(MyObject obj)
        {
            myobj = obj;
        }
        
        public void SetValue(int index, int newValue)
        {
            oldValues[index] = myObj.Ints[index];
            newValues[index] = newValue;
            myObj.Ints[index] = newValue;
        }
        public void Undo(int index)
        {
            myObj.Ints[index] = oldValues[index];
        }
        public void Redo(int index)
        {
            myObj.Ints[index] = newValues[index];
        }
    }
