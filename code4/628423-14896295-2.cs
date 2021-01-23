    class Person {
        [CsvColumn(FieldIndex = 0, CanBeNull = false, Name = "Name")]
        public string Name { get; set; }
        [CsvColumn(FieldIndex = 1, CanBeNull = true, Name = "Last Name")]
        public string Last Name { get; set; }
        [CsvColumn(FieldIndex = 2, CanBeNull = true, Name = "Age")]
        public int Age { get; set; }
    }
