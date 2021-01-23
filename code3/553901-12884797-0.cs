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
        
        public void SetValue(int index, int newValue)
        {
            oldValues[index] = MyObject.Ints[index];
            newValues[index] = newValue;
            MyObject.Ints[index] = newValue;
        }
        public void Undo(int index) { ... }
        public abstract void Redo(int index) { ... }
    }
