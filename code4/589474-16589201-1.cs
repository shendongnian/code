    internal interface IHasPrimaryKey {
        PrimaryKey GetPrimaryKey();
    }
And your compatible ICorrespondent class should implement both interfaces.
    internal class CompatibleCorrespondent : ICorrespondent, IHasPrimaryKey {
        // ...
    }
And the SetRecipient in this case should try a cross-cast of the correspondent to see if it provides the necessary primary key, and fail otherwise.
    var hasPrimaryKey = correspondent as IHasPrimaryKey;
    if(hasPrimaryKey == null) {
        throw new InappropriateSubclassException();
    }
    // ...
    var pk = hasPrimaryKey.GetPrimaryKey();
