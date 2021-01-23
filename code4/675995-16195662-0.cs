    public interface Pet{
        void Feed();
        void Play();
    }
    public class Dog:Pet{
        public void Feed(){
            ...dog feeding code...
        }
        public void Play(){
            ...dog playing code...
        }
    }
    public class Cat:Pet{
        public void Feed(){
            ...cat feeding code...
        }
        public void Play(){
            ...cat playing code...
        }
    }
