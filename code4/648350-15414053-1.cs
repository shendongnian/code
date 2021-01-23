    Message messageParentDomain = 
        _messageRepository.FindSingle(
            m => m.Id == messageDto.MessageParent_Id, 
            includes: new Expression<Func<MyObject, object>>[] {
                i => i.MemberFrom,
                i => i.MemberTo
            }); 
