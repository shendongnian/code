    static void Main(string[] args)
            {
    
                Model m = new Model() {Name = "n", Surname = "s"};
                var q = new Query<Model>();
                q.Eq(x => x.Name).Like(x=>x.Surname).Run(m);
                
    
            }
