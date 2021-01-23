        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
            Blog blog;
            private void button1_Click(object sender, EventArgs e) {
                using (var db = new StackOverflowEntities()) {
                    blog = db.Blogs.Include("Posts")
                        .FirstOrDefault();
                
                }
            }
            private void button2_Click(object sender, EventArgs e) {
                var post = new Post {
                    Text = "Hello World"
                };
            
                using (var db = new StackOverflowEntities()) {
                    db.Attach(blog);
                    blog.Posts.Add(post);
                    db.SaveChanges();
                }
            }
        }
