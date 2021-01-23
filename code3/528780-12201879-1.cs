        private dbContext db = new dbContext();
        public List<Model> method(){
        List<Model> m= List<Model>()   
        var userCategories = db.UserCategories.Include("Users");
        return from item in userCategories select new Model
                 {
                     UserName = item.Users.userName
                     .......
                 }
        }
