    class Subject
    {
        public Int32 Mark { get; set; }
    }
            var subjects = new List<Subject>
            {
                new Subject { Mark = 50 },
                new Subject { Mark = 75 },
                new Subject { Mark = 81 },
            };
            Console.WriteLine(subjects.AsParallel().Sum(subject => subject.Mark));
