    public class DispatchForumPostCommand : ICommand {
        private readonly ForumPostEntity _forumPostEntity;
    
        public ForumPostEntity ForumPostEntity { get { return _forumPostEntity; } }
    
        public DispatchForumPostCommand(ForumPostEntity forumPostEntity) {
            _forumPostEntity = forumPostEntity;
        }
    
        public void Execute() {
            _forumPostEntity.Dispatch();
        }
    }
