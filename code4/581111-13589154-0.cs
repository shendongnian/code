        public void Save(Student student, string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Student));
            ser.WriteObject(fs, student);
            fs.Close();
        }
        public Student Load(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Student));
            Student s = (Student)ser.ReadObject(fs);
            fs.Close();
            return s;
        }
