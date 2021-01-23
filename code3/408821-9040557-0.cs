    public ActionResult Responses(int id, string body)
    {
        // get the ticket
        Ticket ticket = GetTicket(id);
        // create resposne
        Response response = new Response();
        response.Body = body;
 
        // here, you need to ASSOCIATE your response to the ticket you're retrieved!
        response.Ticket = ticket;  // or something like that......
        model.AddToReponses(response);
        model.SaveChanges();
        return RedirectToAction("Ticket", new { id = id });
    }
 
