        static void Main(string[] args)
        {
            const int MAX_ROOMS = 4;
            var cRooms = new System.Collections.Generic.List<Room>();
            for (int nI = 0; nI < MAX_ROOMS; nI++)
            {
                // The room number is 1 to 4
                cRooms.Add(new Room(nI + 1));
            }
            // Initializes the room that wins
            //Start of while loop to ask what room your adding into. 
            while (true)
            {
                Console.Write("Enter the room you're in: ");
                //If user enters quit at anytime, the code will jump out of while statement and enter for loop below
                string roomNumber = Console.ReadLine();
                if (roomNumber == "quit")
                {
                    //Break statement allows quit to jump out of loop
                    break;
                }
                int room = 0;
                if (int.TryParse(roomNumber, out room) && (room < MAX_ROOMS) && (room >= 0)) {
                    Room currentRoom;
                    currentRoom = cRooms[room];
                    Console.Write("Bottles collected in room {0}: ", currentRoom.Number);
                    
                    int wBottleCount = 0;
                    if (int.TryParse(Console.ReadLine(), out wBottleCount) && (wBottleCount >= 0))
                    {
                        // This line adds the count of bottles and records it so you can continuously count the bottles collected.
                        currentRoom.BottleCount += wBottleCount;
                    }
                    else
                    {
                        Console.WriteLine("Invalid bottle count; value must be greater than 0");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid room number; value must be between 1 and " + MAX_ROOMS.ToString());
                }
            }
            Room maxRoom = null;
            foreach (Room currentRoom in cRooms) //This loop goes through the array of rooms (4)
            {
                // This assumes that the bottle count can never be decreased in a room
                if ((maxRoom == null) || (maxRoom.BottleCount < currentRoom.BottleCount))
                {
                    maxRoom = currentRoom;
                }
                Console.WriteLine("Bottles collected in room {0} = {1}", currentRoom.Number, currentRoom.BottleCount);
            }
            //Outputs winner
            Console.WriteLine("And the Winner is room " + maxRoom.Number + "!!!");
        }
