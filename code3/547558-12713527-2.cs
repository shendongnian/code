    [Route("/todo/{id}", "DELETE")]
    public class DeleteTodo : IReturnVoid
    {
        public int Id { get; set; }
    }
