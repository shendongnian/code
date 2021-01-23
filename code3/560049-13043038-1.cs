           public class Student
                {
                    private String name;
                    private String age;
                    public String Name
                    {
                        get { return name; }
                        set { name = value; }
                    }
                    public String Age
                    {
                        get { return age; }
                        set { age = value; }
                    }
                    public override bool Equals(object obj)
                    {
                        Student st = obj as Student;
                        if(st != null ){
                            return (this.name.Trim().ToLower().Equals(st.name.Trim().ToLower()) && this.age == st.age);                        }
                        return base.Equals(obj);
                    }
                }
