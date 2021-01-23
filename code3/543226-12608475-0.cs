    [HttpPost]
    public ActionResult Send(Message message)
    {
        User user = entities.Users.SingleOrDefault(u => u.UserName.Equals(User.Identity.Name));
        User recipient = entities.Users.SingleOrDefault(u => u.UserName.Equals(message.Receiver.UserName));
        ModelState.Clear();
        if (recipient != null && user != null)
        {
            message.Sender = user;
            message.SenderId = user.Id;
            message.Receiver = recipient;
            message.ReceiverId = recipient.Id;
            message.Created = DateTime.Now;
            entities.Messages.Add(message);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(message);
        }
    }
