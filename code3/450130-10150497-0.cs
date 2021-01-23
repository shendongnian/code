    class ClassA
    {
        string CustomerId { get; set; }
        PatientRecords[] Records { get; set; }
        public ClassA(string name, PatientRecords[] records)
        {
            Name = name;
            Records = records;
        }
    }
