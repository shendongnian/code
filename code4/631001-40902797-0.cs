    public IHttpActionResult GetMessages(int messageFeedId, int lastMessageId) {
	    List<Message> messageDomainObjects = MessageService.GetMessages(messageFeedId, lastMessageId);
	    if (messageDomainObjects.Any())
	    {
		    var messages = messageDomainObjects.Select(m => new MessageModel(
			    m.Id,
			    m.Message,
			    m.CreatedDate,
			    m.IsActive,
			    new UserModel(
				    m.User.Id,
				    m.User.FirstName,
				    m.User.LastName
			    )
		    ));
		    return Ok(new { messages = messages });
	    }
	    else
	    {
		    return Ok(new { });
	    }
    }
