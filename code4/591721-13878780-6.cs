    public partial class Form1 : Form {
                public Form1() {
                    InitializeComponent();
                }
                Blog blog;
                private void fetchBlogData_Click(object sender, EventArgs e) {
                    using (var db = new StackOverflowEntities()) {
                        blog = db.Set<Blog>().Include("Posts")
                            .FirstOrDefault();
                
                    }
                }
                private void commitAllPosts_Click(object sender, EventArgs e) {
            
                    using (var db = new StackOverflowEntities()) {
                    
                        // load existing blog into ChangeTracker
                        var existingBlog = db.Set<Blog>().First(b => b.BlogId == blog.BlogId);
                        // if the root blog record must be updated
                        //db.Entry(existingBlog).State == EntityState.Modified;
                        // add new posts to tracked Blog entity
                        foreach (var post in blog.Posts) {
                            if (post.PostId == 0) {
                                // this only works if your Post record has a primary key has Identity Specification set to yes
                                existingBlog.Posts.Add(post);
                            }
                        }                    
                        db.SaveChanges();
                    }
                }
                private void createArbPosts_Click(object sender, EventArgs e) {
                    var post = new Post {
                        Text = "Today I read but never understood a StackOverflow question.... again."
                    };
                    blog.Posts.Add(post);
                    var postPS = new Post {
                        Text = "Actually, i'm not sure i understand it yet."
                    };
                    blog.Posts.Add(postPS);
                }
            }
