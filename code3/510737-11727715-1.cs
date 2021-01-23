    [ServiceContract]
    public partial class BookmarkService
    {
        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}")]
        [OperationContract]
        void PutUserAccount(string username, User user) {...}
        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}")]
        [OperationContract]
        void DeleteUserAccount(string username) {...}
        [WebInvoke(Method = "POST", UriTemplate = "users/{username}/bookmarks")]
        [OperationContract]
        void PostBookmark(string username, Bookmark newValue) {...}
        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}/bookmarks/{id")]
        [OperationContract]
        void PutBookmark(string username, string id, Bookmark bm) {...}
        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}/bookmarks/{id}")]
        [OperationContract]
        void DeleteBookmark(string username, string id) {...}
        ...
    }
