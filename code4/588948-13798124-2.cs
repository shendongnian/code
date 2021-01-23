    using System;
    using System.IO;
    using System.Text;
    public class Movie
    {
         public string Name { get; set; }
         public IList<string> Cast { get; set; }
         public override string ToString()
         {
             var s = new StringBuilder();
             s.AppendFormat("Movie: {0}", this.Name);
             s.AppendLine();
             for (var i = 0; i < this.Cast.Count; i++)
             {
                 s.AppendFormat(
                     "  Cast #:{0}, Member: {1}",
                     i + 1,
                     this.Cast[i]);
                 s.AppendLine();
             }
             return s.ToString();
         }
    }
    public class MovieData
    {
        public void MovieData(string filePath)
        {
            this.Movies = File.ReadAllLines(filePath).Select(line =>
                new Movie
                {
                    // Something here that makes sense.
                });
        }
        
        public IList<Movie> Movies { get; private set; }
    }
