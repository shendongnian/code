        var users = UserRepository.Get();
        var userEmailSettings = UsersEmailSettingRepository.Get();
        var emailLogs = EmailLogRepository.Get();
        var posts = ForumPostRepository.Get();
    	var foo = 
			from user in users
            where posts
                   .Any(post => post.UserId == u.Id && post.TopicId == topicId)
            where userEmailSettings
                   .Any(ues => u.Id equals ues.UserId && ues.ReplyToTopic == true)
			where false == 
			(
					from el in emailLogs
					where el.Type == "ReplyToTopic"
					&& el.Values == topicId
					&& el.UserId == user.Id
					&& el.Created > user.LastLogin
					select el
			).Any()
			select user;
