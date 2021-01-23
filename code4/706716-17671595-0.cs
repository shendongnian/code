    private void LimitProperties(object entity, List<string> keepProps) {
        if (entity == null)
        {
            return;
        }
    
        PropertyInfo[] props = entity.GetType().GetProperties();
        foreach (PropertyInfo prop in props)
        {
            if (!keepProps.Contains(prop.Name))
            {
                prop.SetValue(entity, null);
            }
        }
    }
    
    public Models.Message GetMessageByID(int messageID) {
        List<string> _validProps = new List<string> { "ID", "Name", "Title" };
    
        Models.Message message = DbContext.Messages
            .Include(m => m.RefChannel)
            .Include(m => m.RefSender)
            .Include(m => m.RefRecipient)
            .AsNoTracking()
            .FirstOrDefault(m => m.ID == messageID);
    
        // limit the number of returned fields
        if (message != null)
        {
            LimitProperties(message.RefChannel, _validProps);
            LimitProperties(message.RefSender, _validProps);
            LimitProperties(message.RefRecipient, _validProps);
        }
    
        return message;
    }
