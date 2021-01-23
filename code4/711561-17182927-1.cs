    foreach(Student s in listStudents){
        listView1.Items.Add(new string[]{
            s.Property1, s.Property2, s.Property3, s.Property4
        });
    }
