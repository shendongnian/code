    public partial class AddPersonDialogue : Form
    {
        public Läggtill()
        {
            InitializeComponent();            
            
        }
    	
    	public void SetUpPeople(List<person> personStorage)
    	{
    		foreach (person p in personStorage)
            {
              //do stuff
            }
    	}
    }
    
     public Form1()
     {
        {
            InitializeComponent();
        }      
    
        public List<person> personStorage = new List<person>();
    	
    	public void ShowForm()
    	{
    		var dialogue = new AddPersonDialogue();
    		
    		dialogue.SetUpPeople(personStorage);
    		
    		dialogue.Show();
    	}
    }
