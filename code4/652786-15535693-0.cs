     List<Ticket> supportTickets = (from xElement in doc.Descendants("tickets")
                              select new Job
                              {
                                ID = ticket.Element("id").Value,
                                TicketID = ticket.Element("tid").Value,
                                DeptID = ticket.Element("deptid").Value,
                                UserID = ticket.Element("userid").Value,
                                Name = ticket.Element("name").Value,
                                Email = ticket.Element("email").Value,
                                Subject = ticket.Element("subject").Value,
                                Message = ticket.Element("message").Value,
                             }).ToList();
