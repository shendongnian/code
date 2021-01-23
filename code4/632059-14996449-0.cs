    public class MyService
    {
        IEnumerable<UserWithMessages> Find()
        {
            var messages = _messageRepository.FindAll();
            var userIds = _messages.Select(x => x.UserId).Distinct().ToArry();
            var users = _userRepository.Find(userIds);
            return users.Select(x => new UserWithMessages(x, messages.Where(x => x.UserId == x.Id));
        }
    }
