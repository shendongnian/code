    public void UpdatePosition(int playerID, PlayerPosition newPosition)
    {
        Player existingPlayer = playersRepository.GetByID(playerID);
        existingPlayer.Position = newPosition;
        this.Save(existingPlayer);  // assuming you have a Save method on the repository
    }
