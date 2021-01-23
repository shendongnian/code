    public class PostsService
    {
        protected IConnectionFactory Connection;
        // Initialization here ..
        public async Task TestPosts_Async()
        {
            // Normal way..
            var posts = Connection.Scope(cnn =>
            {
                var state = PostState.Active;
                return cnn.Query<Post>("SELECT * FROM [Posts] WHERE [State] = @state;", new { state });
            });
            // Async way..
            posts = await Connection.ScopeAsync(cnn =>
            {
                var state = PostState.Active;
                return cnn.QueryAsync<Post>("SELECT * FROM [Posts] WHERE [State] = @state;", new { state });
            });
        }
    }
