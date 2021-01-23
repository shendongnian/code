    public partial class Question:XPObject
    {
        protected override void OnSaving()
        {
            if(this.Answers.Count == 1) base.OnSaving();
            else throw new UserFriendlyException( "You need to have one correct answer." );
        }
    }
