    interface IUser<out PostType>
    {
        PostType Post { get; }
    }
    interface IPost<out UserType>
    {
        UserType User { get;  }
    }
