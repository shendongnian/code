    var cachedHotel = context.Hotels.Local
        .FirstOrDefault(h => h.id = editedHotel.id);
    if (cachedHotel != null)
    {
      context.Hotels.Detach(cachedHotel);
    }
    context.Hotels.Attach(editedHotel);
    context.Entry(editedHotel).State = System.Data.EntityState.Modified;
    context.SaveChanges();
