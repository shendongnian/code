    Use MVVM pattern to access properties of the control and modify them
    
    public class Student
    {
     public Student()
    {
    }
        public string Name
        {
            get { return "Setting Text from My Program"; }
        }
    }
    
    Set the DataContext of the xaml in the code behind
    this.DataContext=new Student();
    
    Bind the Text property to Name 
    <TextBlock Text="{Binding Name}"/>
