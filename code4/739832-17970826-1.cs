    if ((MousePosition.X+1) % 30 < 3)
    {
        int newX = MousePosition.X + 1 - ((MousePosition.X+1) % 30);
        PBList[14].Location = new Point(PList[parent].PointToClient(new Point(newX, MousePosition.Y)).X, PBList[14].Location.Y);
    }
    //Same for Y
