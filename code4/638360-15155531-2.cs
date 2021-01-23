    parties.Sort((p1, p2) =>
    {
        if (p1.HasReservation != p2.HasReservation)
            return p1.HasReservation ? 1 : 0;
        else
            return p1.PersonCount.CompareTo(p2.PersonCount);
    });
