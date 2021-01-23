    foreach (SubjectInfo info in student.SubjectInfoList)
    {
       TextBox tb = new TextBox();
       ///...
       tb.DataContext = info;
       Binding binding = new Binding("marks");
       tb.SetBinding(TextBox.TextProperty, binding);
       ///...
    }
