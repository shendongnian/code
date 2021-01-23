            while (rowRequest < 12)
            {
                    for (int seat = req.seat; seat < 16; seat++)
                    {
                        if (reservedSeat[req.row, seat])
                        {
                        //Loop back
                        }
                        else
                        {
                            emptySeat = true;
                            seatCopy = seat;
                            break;
                        }
                }
                if (reservedSeat[req.row, 15])
                {
                    seatCopy = 0;
                    break;
                }
            }
