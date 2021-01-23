    DisplayMenu thisdm = new DisplayMenu();
    int menuChoice = -1;
    while (menuChoice < 1 || menuChoice > 3)
    {
        Console.WriteLine("enter valid choice");
        menuChoice = thisdm.displayMenu();
    }
    ProcessMenu thispm = new ProcessMenu();
    thispm.processMenu(menuChoice);
