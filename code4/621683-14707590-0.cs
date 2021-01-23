    public void AddClient(Client clientToAdd)
    {
        string client = clientToAdd.FirstName + "," + clientToAdd.LastName + "\r\n";
        File.AppendAllText(textFilePath, client);
    }
