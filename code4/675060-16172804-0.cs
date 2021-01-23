    public interface ISpawn<T> where T : Animal
    {
        public T GiveBirth();
    }
    
    public void Populate<T>(T parent, ISpawn<T> spawn) where T : Animal
    {
    }
