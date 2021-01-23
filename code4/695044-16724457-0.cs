    List<Student> students = new List<Student>();
    double dub = 0;
    items = MyListBox.Items.Cast<String>().ToList();
    
    for (int i = 0; i < items.Length; i++)
    {
         if (i % 2 == 0)
         {
             dub = double.Parse(items[i]);
         }
         else
         {
             Student s = new Student();
             s.Name = items[i];
             s.Marks = dub;
             students.Add(s);
         }
    }
