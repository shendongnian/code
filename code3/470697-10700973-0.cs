    public class Axe {
    
        private byte[] data = new byte[whateverLength];
        
        public byte this[int index] {
            get { return data[index]; }
            set { data[index] = value; }
        }
    
    }
