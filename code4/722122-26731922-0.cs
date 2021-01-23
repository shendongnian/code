    protected static Stream GetStream<T>(T content)
    {
        MemoryStream memoryStream = new MemoryStream();
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), new []{typeof(Post), typeof(User)});
        serializer.WriteObject(memoryStream, content);
        memoryStream.Seek(0, SeekOrigin.Begin);
        return memoryStream;
    }
    protected static T GetObject<T>(Stream stream)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), new[] { typeof(Post), typeof(User) });
        return (T)serializer.ReadObject(stream);
    }
    static void Main(string[] args)
    {
        var container = new Container {PostsAndUsers = new List<object>()};
        container.PostsAndUsers.Add(new Post{Content = "content1"});
        container.PostsAndUsers.Add(new User{UserName = "username1"});
        container.PostsAndUsers.Add(new Post { Content = "content2" });
        container.PostsAndUsers.Add(new User { UserName = "username2" });
        var stream = GetStream(container);
        var parsedContainer = GetObject<Container>(stream);
        foreach (var postsAndUser in parsedContainer.PostsAndUsers)
        {
            Post post;
            User user;
            if ((post = postsAndUser as Post) != null) 
            {
                // is post
            }
            else if ((user = postsAndUser as User) != null) 
            {
                // is user
            }
            else
            {
                throw new Exception("");
            }
        }
    }
