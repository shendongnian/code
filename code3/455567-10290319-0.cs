        public Student getStudent(int age, string name)
        {
            Student entity = this.getData().Find(s => Convert.ToInt32(s.Age) == age && s.Name.Equals(name));
            return entity;
        }
