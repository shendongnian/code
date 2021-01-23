    void RunTransaction(Action<IDbCommand> action)
    {
    using(var cnn=GetConnection)
    cnn.Open();
    using(var trans=cnn.BeginTransaction())
    {
    var command=cnn.CreateCommand();
    action(command);
    trans.Commit();
    }
    }
