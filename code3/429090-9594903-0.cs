    public partial class frmSchedule : Window 
    {       
       ...  
       private void btnAdd_Click(object sender, RoutedEventArgs e)  
       {  
        //New frmAddLesson window  
        frmAddLesson addLesson = new frmAddLesson(this);  
        addLesson.Show();  
       }  
       public void AddLesson(Lesson lesson)
       {
         ...
       }
    }
    public partial class frmAddLesson : Window    
    {
      public frmAddLesson(frmSchedule schedule)      
      {      
        InitializeComponent();      
        this.schedule = schedule;
        ...
      
      }    
      frmSchedule schedule;
    
      //ADD LESSON    
      private void btnAdd_Click(object sender, RoutedEventArgs e)    
      {    
        //Create new Lesson object    
        var theLesson = new Lesson();    
    
        //Set Lesson property    
        theLesson.Time = (int)cmbTime.SelectedValue; //Time    
    
        schedule.AddLesson(theLesson);
      
        this.Close();    
      }    
    }    
