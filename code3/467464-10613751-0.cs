    [HttpPost]
    public ActionResult Message_Send_Get(MessageModel message_to_send)
    {
        if (ModelState.IsValid)
        {
            // the model is valid => do whatever you intended to do with the model here
            // use the message_to_send properties here
        }
        // since we want to redisplay the same view we need to reassign the
        // MessagesList property used by the dropdown because in HTML a dropdown
        // sends only the selected value when the form is submitted and not the entire
        // list of options
        message_to_send.MessagesList = smse.Messages
           .Select(c => new SelectListItem
           {
               Value = c.message1,
               Text = c.message1
           });
        return View(message_to_send);
    }
