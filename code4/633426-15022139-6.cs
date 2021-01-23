    public IEnumerable<int> GetAllPersonIdsFrom(IEnumerable<Message> messages)
    {
         foreach(var message in messages)
         {
             yield return message.CreatedByPerson;
             if (message.PostedToPersonID.HasValue)
                 yield return message.PostedToPersonID.Value;
         }
    }
