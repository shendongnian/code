    [Route("/todo/{id}/delete", "POST")]
    public class DeleteTodo : IReturnVoid
    {
        public int Id { get; set; }
    }
