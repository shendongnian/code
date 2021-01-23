    public class Pin
    {
        private readonly ObservableCollection<Comment> commentList = new ObservableCollection<Comment>();        
        public ObservableCollection<Comment> CommentList
        {
            get
            {
                return commentList;
            }
        }
    }
    
