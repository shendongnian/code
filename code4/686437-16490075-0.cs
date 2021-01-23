    [Route("/students/{Id}")]
    public GetStudent : IReturn<Student>
    {
        public int Id { get; set; }
    }
