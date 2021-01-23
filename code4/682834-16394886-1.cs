	var foo = 
			from user in UserRepository.Get()
            where ForumPostRepository.Get()
                   .Any(post => post.UserId == u.Id && post.TopicId == topicId)
            where (UsersEmailSettingRepository.Get()
                   .Any(ues => u.Id equals ues.UserId && ues.ReplyToTopic == true)
			where false == 
			(
					from el in EmailLogRepository.Get()
					where el.Type == "ReplyToTopic"
					&& el.Values == topicId
					&& el.UserId == user.Id
					&& el.Created > user.LastLogin
					select el
			).Any()
			select user;
