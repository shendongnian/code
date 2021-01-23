    for (int i = 0; i < rs.Count; i++)
    {
       r.ReservationTime = r.ReservationTime.AddTicks(-r.ReservationTime.Ticks % 10000000);
       rs[i].ReservationTime = rs[i].ReservationTime.AddTicks(-rs[i].ReservationTime.Ticks % 10000000);
    }
