    [HttpPatch]
    public IHttpActionResult PatchMultiple(DeltaCollection<Todo> todos)
    {
        foreach (var todo in todos)
        {
            if (todo.TryGetPropertyValue(nameof(Todo.id), out int id))
            {
                // Entity to update (from your datasource)
                var entityToPatch = Todos.FirstOrDefault(x => x.id == Convert.ToInt32(id));
                if (entityToPatch == null) return BadRequest("Todo not found (Id = " + id + ")");
              
                person.Patch(entityToPatch);
            }
            else
            {
                return BadRequest("Id property not found for a todo");
            }
        }
        return Ok();
    }
