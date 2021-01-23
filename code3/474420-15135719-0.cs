    public class PostByNameIndex : AbstractIndexCreationTask<Posts>
    {
        public PostByNameIndex()
        {
            Map = posts => posts.Select(x => new {x.Name});
            Analyze(x => x.Name, typeof(NGramAnalyzer).AssemblyQualifiedName);
         }
    }
