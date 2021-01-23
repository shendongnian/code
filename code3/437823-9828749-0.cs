    public class MainViewModel: ViewModelBae
    {
    	ObservableCollection<MountainViewModel> mountains
    	public ObservableCollection<MountainViewModel> Mountains
        {
    		get { return mountains; }
            set
            {
    			if (mountains != value)
    			{
    				mountains = value;
    				RaisePropertyChanged("Mountains");
                }
    		}
        }
    	MountainViewModel selectedMountain
    	public MountainViewModel SelectedMountain
        {
    		get { return selectedMountain; }
            set
            {
    			if (selectedMountain != value)
    			{
    				selectedMountain = value;
    				RaisePropertyChanged("SelectedMountain");
                }
    		}
        }
    }
    
    public class MountainViewModel: ViewModelBae
    {
    	ObservableCollection<LiftViewModel> lifts
    	public ObservableCollection<LiftViewModel> Lifts
        {
    		get { return lifts; }
            set
            {
    			if (lifts != value)
    			{
    				lifts = value;
    				RaisePropertyChanged("Lifts");
                }
    		}
        }
    	LiftViewModel selectedLift
    	public LiftViewModel SelectedLift
        {
    		get { return selectedLift; }
            set
            {
    			if (selectedLift != value)
    			{
    				selectedLift = value;
    				RaisePropertyChanged("SelectedLift");
                }
    		}
        }
    }
    
    public class LiftViewModel: ViewModelBae
    {
    	ObservableCollection<string> runs
    	public ObservableCollection<string> Runs
        {
    		get { return runs; }
            set
            {
    			if (runs != value)
    			{
    				runs = value;
    				RaisePropertyChanged("Runs");
                }
    		}
        }
    	string selectedRun
    	public string SelectedRun
        {
    		get { return selectedLift; }
            set
            {
    			if (selectedLift != value)
    			{
    				selectedLift = value;
    				RaisePropertyChanged("SelectedLift");
                }
    		}
        }
    }
    
    <ListBox ItemsSource="{Binding Mountains}" SelectedItem="{Binding SelectedMountain, Mode=TwoWay}">
    <ListBox ItemsSource="{Binding SelectedMountain.Lifts}" SelectedItem="{Binding SelectedMountain.SelectedLift, Mode=TwoWay}">
    <ListBox ItemsSource="{Binding SelectedMountain.SelectedLift.Runs}" SelectedItem="{Binding SelectedMountain.SelectedLift.SelectedRun, Mode=TwoWay}">
