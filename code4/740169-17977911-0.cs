    public class TimeTaskViewModel : TimeDetailTask
    {
        public string TaskTypeDescription { get; set; }
    
       public TimeDetailTask TimeDetailTaskProperty { get; set; }
    }
    
    //Then you assign the entity values to modelclass  TimeDetailTaskProperty 
    public TimeTaskViewModel ConvertClassToViewModel(TimeDetailTask entity)
    {
        TimeTaskViewModel viewModel = new TimeTaskViewModel ();    
        viewModel.TimeDetailTaskProperty =entity;
        return viewModel;
    }
