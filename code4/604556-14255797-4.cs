    public interface ICodeCommandHandler
    {
        int Save(CodeTagViewModel input);
    }
    public class CodeCommandHandler : ICodeCommandHandler
    {
        private IRepository<Code> repository;
        public CodeCommandHandler(IRepository<Code> repository)
        {
            this.repository = repository;
        }
        public int Save(CodeTagViewModel input)
        {
            Code code = new Code();
            Tag tag = new Tag();
            code.Title = input.Title;
            code.Description = input.Description;
            code.DateAdded = input.DateAdded;
            code.LastUpdated = input.LastUpdated;
            code.Project = input.Project;
            code.CMS = input.CMS;
            code.DotNetVersion = input.DotNetVersion;
            code.Dependencies = input.Dependencies;
            code.Author = input.Author;
            code.CodeFile = input.CodeFile;
            code.TFSLocation = input.TFSLocation;
            code.Tags.Add(tag);
            return repository.Save(code);
        }
    }
