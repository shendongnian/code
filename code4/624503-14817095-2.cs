    (from u in Users
     select new 
        {
        u.Id, u.Reputation,Comments = ( from c in u.Comments 
                                        select new YourClass {comment = c, 
                                                              post= c.Post})
        }
    )
    .Take(10)
    .....
    public Class YourClass
        {
        public Comment comment {get;  set;}
        public Post post {get;set;}
        }
