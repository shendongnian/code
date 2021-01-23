    List<Ticket> supportTickets = 
        (from x in doc.Descendants("ticket")
         select new Ticket
         {
             ID = x.Element("id").Value,
             TicketID = x.Element("tid").Value,
             DeptID = x.Element("deptid").Value,
             UserID = x.Element("userid").Value,
             Name = x.Element("name").Value,
             Email = x.Element("email").Value,
             Subject = x.Element("subject").Value,
             Message = x.Element("message").Value,
         }).ToList();
