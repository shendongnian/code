    var memberColumnEnum = column as Enums.MemberColumn
    if(memberColumnEnum != null)
    {
        switch (memberColumnEnum)
        {
            case Enums.MemberColumn.Address1:
                return DbType.String;
            case Enums.MemberColumn.City:
                return DbType.String;
            case Enums.MemberColumn.State:
                return DbType.String;
            default:
                throw new ArgumentException("Unsupported enum type.", "MemberColumn");
        }
    }
