    public class Practical {
        ...
    public event EventHandler QNChanged;
    public event EventHandler FcChanged;
    public String QN
    {
        get { return QuestionNumber; }
        set
        {
            QuestionNumber = value;
            OnQNChanged();     //notify about new question
        }
    }
    public String Fc
    {
        get { return Factor; }
        set
        {
            Factor = value;
            OnFcChanged();     //notify about new ffctor
        }
    }
    protected void OnFcChanged(){
        if(this.FcChanged != null) {
             FcChanged(this, null);
        }
    }
    protected void OnQnChanged(){
        if(this.QnChanged != null) {
             QnChanged(this, null);
        }
    }
    ...
    }
    public class Student {
         public Student(Practical practical){
              practical.QnChanged += Update;
         }
         public void Update(object sender, EventArgs args){
              Practical practical = (Practical) sender;
              // do something with practical
         }
    }
    public class Staff{
         public Staff(Practical practical){
              practical.FnChanged += Update;
         }
         public void Update(object sender, EventArgs args){
              Practical practical = (Practical) sender;
              // do something with practical
         }
    }
    class Observer
    {
    public static void Main()
    {
        ....
        var practical = new Practical("Question", "Factor");
        var a = new Student(practical);
        var b = new Staff(practical);
        
        practical.QN = "Question 1";   // all students notified about Question 1 
        practical.Fc = "Feel-Good";
        practical.QN = "Question 2";   // all students notified about Question 2
        practical.Fc = "Feel-Bad";
        ....
      }
     } 
