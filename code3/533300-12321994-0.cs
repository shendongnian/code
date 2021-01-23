    pDialog.PrintTicket.PropertyChanged += new PropertyChangedEventHandler(PrintPropertyChanged);
    
    private void PrintPropertyChanged(object sender, EventArgs e){
        PageOrientation SelectedPageOrientation = pDialog.PrintTicket.PageOrientation;
        //save the orientation, or save the entire PrintTicket if you want.
    }
