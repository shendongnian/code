    [Route("/students")]
    public FindStudents : IReturn<List<Student>>
    {
        public int? Id { get; set; }
        public string Email { get; set; }
    }
