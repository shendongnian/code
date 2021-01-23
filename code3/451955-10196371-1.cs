    RoomList roomList = new RoomList();
    ...
    for (int i = 0; i < roomList[0].Length; i++) {
        var doublyBooked = roomList.Column(i)
            .GroupBy(e => e.Type)
            .Where(g => g.Count() > 1).Select(g => g.Key);
        if (doublyBooked.Any()) {
            Console.WriteLine("Doubly booked accompanists in slot {0}", i);
            foreach (var accompanist in doublyBooked) {
                Console.WriteLine("    {0}", accompanist);
            }
        }
    }
