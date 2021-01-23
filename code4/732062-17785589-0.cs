    public class BookingManager : IBookingManager
    {
         // References to your database context
    
         public IEnumerable<Ticket> GetAllTickets()
         {
              return databaseContext.Tickets;
         }
    }
