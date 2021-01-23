    public class NoteRepository: BaseEfRepository<Note, MyContext>
    {
        public NoteRepository(MyContext uow) : base(uow)
        {
            MyEntitySet = uow.Notes;
        }
        public Note GetSingleWithParties(Expression<Func<Note, bool>> whereCondition)
        {
            return [... whatever ...]
        }
    }
