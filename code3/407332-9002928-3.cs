    class ItemFactory<T>
    {
        public T GetNewItem()
        {
            return new T(); // error here => you cannot call the constructor because you don't know if T possess such constructor
        }
    }
