    public class MessageRepository : IMessageRepository<Message>
    {
      //
      // ...
      //
      void Add(Message message)
      {
        //
        // add to database code
        //
        // some logging utility that's tracking transactions against specific
        // database elements and reporting them back to some notification log
        // that can then be output to the admin
        this.LogTransaction<Message>(message, TransactionType.Create); 
      }
    }
