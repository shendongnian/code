    public class IdeaByBodyOrTitle : AbstractIndexCreationTask<Idea>
    {
        public IdeaByBodyOrTitle()
        {
            Map = ideas => from idea in ideas
                           select new
                               {
                                   idea.Title,
                                   idea.Body
                               };
        }
    }
