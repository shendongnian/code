    public ActionResult Responses(int id, string body)
    {
        // get the ticket
        Ticket ticket = GetTicket(id);
        // create resposne
        Response response = new Response();
        response.Body = body;
 
        // *** BEGIN NEW SECTION ***
        // here, you need to ASSOCIATE your response to the ticket you're retrieved!
        response.Ticket = ticket;  // or something like that......
        // or maybe:
        response.TicketId = ticket.Id;  // or something like that......
        // *** END NEW SECTION ***
        model.AddToReponses(response);
        model.SaveChanges();
        return RedirectToAction("Ticket", new { id = id });
    }
 
