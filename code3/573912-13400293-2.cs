    public void Do(int id)
    {
        long sequenceNo = _ringBuffer.Next();
        _ringBuffer[sequenceNo].Id = id;
        sw[id].Restart(); // <--- You're doing this EVERY TIME YOU PUBLISH an item!
        _ringBuffer.Publish(sequenceNo);
    }
