    public ICommand DisplaySelectedItemCmd { get; protected set; }
    
    //This method goes in your constructor
    private void InitializeCommands()
    {
            //Initializes the command
            this.DisplaySelectedItemCmd = new RelayCommand(
                (param) =>
                {
                    this.DisplaySelectedItem((int)param);
                },
                (param) => { return this.CanDisplaySelectedItem; }
            );
        
        //The parameter should be your listview's selected item. I have no idea what type it is so I made it an object
        public void DisplaySelectedPolicy(object selectedListViewItem)
        {
            //Code to perform when item is double clicked
        }
        
        private bool CanDisplaySelectedPolicy
        {
            get
            {
                return true; //Change this bool if you have any reason to disable the double clicking, as this bool basically is linked to the double click command firing.
            }
        }
        
