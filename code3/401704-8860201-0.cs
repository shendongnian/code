    public abstract class EminenceCommand : UserCommand 
    { 
            public override bool CanBeExecutedBy(IUserThatExecutesCommands user) 
            { 
                // Dynamically check the type of user passed in and only check priveleges if correct type
                IUserThatExecutesEminenceCommands u = user as IUserThatExecutesEminenceCommands;
                if( u == null) {
                     return false;
                }
                return u.Eminence >= _requiredEminence; 
            } 
    } 
