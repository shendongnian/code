    public interface ITransformer<out To, in From>
        where To : class
    {
        To Transform(From instance);
    }
    
    public class SomeDataToSomeViewModelTransformer : ITransformer<SomeViewModel, SomeDataModel>
    {
        public SomeViewModel Transform(SomeDataModel instance)
        {
            return new SomeViewModel
                {
                    InvitationId = instance.Id,
                    Email = instance.EmailAddress,
                    GroupId = instance.Group.Id
                };
        }
    }
