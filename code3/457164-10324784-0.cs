    public HttpResponseMessage Put(Todo todo){
    var item = _db.Todo.First(i => i.id = todo.id);
    item.Content = todo.Content;
    item.Done = todo.Done;
    _db.SaveChanges();
    return new HttpResponseMessage<Todo>(HttpStatusCode.Accepted);
    }
