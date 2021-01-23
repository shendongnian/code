    private void InsertLinks(IEnumerable<string> urls)
       {
           EntityDataModelContext context = DataContext.GetDataContext();
    
           var withhashes=urls.Select(u=>new {Url=u,Hash= Hash(u)});
           withhashes.Where(h=>!context.Links.Any(l=>l.UrlHash==h.Hash))
              .ToList()
              .ForEach(h=> {
               	context.Links.Add(new Link(){
                       Url = h.Url
                       });
                   });
    
              context.SaveChanges();
    
          
    
       }
    
       private bool Hash( string url)
       {
           SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
           byte[] encoded = Encoding.ASCII.GetBytes(url);
           byte[] checksum = sha.ComputeHash(encoded);
           long hash = BitConverter.ToInt64(checksum, 0);
           return  hash;
       }
