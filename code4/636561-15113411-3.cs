    protected string ProcessName(Post post){
        if(User.IsInRole("Admin")){
            return post.Name;
        }
        return post.Role;
    }
