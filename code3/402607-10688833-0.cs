    public class Post
    {
        public string ID { get; set; }
    
        public BaseUser From { get; set; }
    
        public string Text { get; set; }
    
        public ItemType Type { get; set; }
    
        public string Picture { set; get; }
    
        public string Link { set; get; }
    
        public string CreatedTime { get; set; }
    
        public string UpdatedTime { get; set; }
    }
    
    public class BaseUser
    {
        public string ID { get; set; }
    
        public string Name { get; set; }
    }
    
    public enum ItemType
    {
        Story,
        Message
    }
    
    
    
        try
                    {
                        List<Post> posts = new List<Post>();
                         
                        dynamic p = (IDictionary<string, object>)fb.Get(userID + "/feed");
        
                        foreach (dynamic item in p.data)
                        {
                            try
                            {
                                Dictionary<string, object>.KeyCollection keys = item.Keys;
        
                                Post post = new Post();
        
                                if (keys.Contains<string>("story"))
                                {
                                    post.Type = ItemType.Story;
                                    post.Text = item.story;
                                    post.Link = item.link;
                                    post.Picture = item.picture;
                                }
                                else if (keys.Contains<string>("message"))
                                {
                                    post.Type = ItemType.Message;
                                    post.Text = item.message;
                                    //post.Link = user.Link;
                                    //post.Picture = item.picture;
                                }
        
                                keys = null;
        
                                post.ID = item.id;
                                post.UpdatedTime = item.updated_time;
                                post.CreatedTime = item.created_time;
        
                                BaseUser baseUser = new BaseUser();
        
                                dynamic from = item.from;
                                baseUser.ID = from.id;
                                baseUser.Name = from.name;
                                post.From = baseUser;
                                posts.Add(post);
        
                            }
                            catch (Exception)
                            {
        
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
