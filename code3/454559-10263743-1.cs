    public void AddStudent(Student student)
    {
        student.StudentID = (++eCount).ToString();
        byte[] passwordHash = Hash(student.Password, GenerateSalt());
    
    	StringBuilder stringBuilder = new StringBuilder();
    	
    	foreach(byte b in passwordHash){
    		stringBuilder.AppendFormat("{0:X2}", b);
    	}
    
        student.TimeAdded = DateTime.Now;
        student.Password= stringBuilder.ToString();;
        students.Add(student);
    }
