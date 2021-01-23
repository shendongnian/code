    var key = clientsInRoom.Where(pair => pair.Value == clientSocket)
                           .Select(pair => pair.Key)
                           .FirstOrDefault();
    if (key != null)
    {
        clientsInRoom.Remove(key);
    }
