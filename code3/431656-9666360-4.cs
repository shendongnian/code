    public bool IsAllGoodSeats(List<Seat> seats, int goodNumber)
    {
        if(seats.Count % goodNumber != 0)
            return false;
        for(int i = 0; i < seats.Count; i += goodNumber)
        {
            var subSeats = new List<Seat>();
            for(int s = i; s < i + goodNumber; s++)
                subSeats.Add(seats[s]);
            if(!IsGoodSeats(subSeats, goodNumber))
                return false;
        }
        return true;
    }    
