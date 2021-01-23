public class Post : Entity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public DateTime Added { get; set; }
    public MongoDBRef Owner { get; set; }
}    
Then you can:
var mongo = new Mongo(config.BuildConfiguration());
mongo.Connect();        
var DB = mongo.GetDatabase(_dataBaseName)
var post = new Post();
post.Owner = new MongoDBRef("User", userId); // First parameter is a mongoDB collection name and second is object id
// To fetch object referenced by DBRef you should do following
var owner = DB.FollowReference<User>(post.Owner);
