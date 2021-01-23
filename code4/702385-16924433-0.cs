       public class RequestRepository : IRequestRepository
       {
            /* other code here */
            public Request Latest(Ticket ticket)
            {
               // I'm also assuming you're using an auto incremented CaseId
               return this.context.tblRequests.OrderByDescending(p => p.CaseId).FirstOrDefault(p => p.UEmailAddress == ticket.UEmailAddress);
            }
        }
