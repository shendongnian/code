    var todoListIds = _dbSession.Query<UserTreeNode>()
        .Include(x => x.TodoListId)
        .Where(x => x.UserId == user.Id)
        .Select(x => x.TodolistId);
    
    foreach (var userListId in todoLisIds)
    {
        //This won't cause an extra network call, because the session will have already loaded it
        var todoList = _dbSession.Load<TodoList>(userListId);
        //In-memory filtering to get the outstanding items
        var activeItems = todoList.Items.Where(x => x.IsCompleted).ToList();
    }
