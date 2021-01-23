    void ConsumingTaskBody()
    {
        bool available;
        do
        {
            available = _collection.TryGetNext(out item);
            Process(item);
        }while(available);
    }
