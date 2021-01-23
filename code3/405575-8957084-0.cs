    public Room(int roomIndex, string basicRoomDescript, Dictionary<string, int> availableExits)
    {
        roomNumber = roomIndex;
        roomDescription = basicRoomDescript;
        this.availableExits = availableExits;
    }
