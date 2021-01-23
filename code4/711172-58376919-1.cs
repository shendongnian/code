                string sql = @"select 
                              t.Id,
                              t.Title,
                              t.Message,
                              t.CreatedOn,
                              s.Id as Id,
                              s.Name,
                              c.Id as Id,
                              c.Name,
                              u.Id as Id,
                              u.Name,
                              u.Surname,
                              u.Active
                             from ToDoItem t
                            inner join [Status] s on (t.StatusId = s.Id)
                            inner join [Category] c on (t.CategoryId = c.Id)
                            inner join [User] u on (t.AssignUserId = u.Id)";
                var result = connection.Query<TodoItem, Status, Category, User, TodoItem>
                    (sql, (todoItem, status, category, user) =>
                {
                    todoItem.Status = status;
                    todoItem.Category = category;
                    todoItem.User = user;
                    return todoItem;
                },splitOn: "Id,Id,Id,Id");
