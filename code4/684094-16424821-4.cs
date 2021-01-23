    public interface IMutableBox
    {
        void SetIsRed(bool isRed);
        void SetIsEmpty(bool isEmpty);
    }
    public class Box : IMutableBox
    {
        private bool isRed;
        private bool isEmpty;
        
        public bool IsRed { get { return isRed; } }
        public bool IsEmpty { get { return isEmpty; } }
 
        void IMutableBox.SetIsRed(bool isRed)
        {
            this.isRed = isRed;
        }
        
        void IMutableBox.SetIsEmpty(bool isEmpty)
        {
            this.isEmpty = isEmpty;
        }
    }
