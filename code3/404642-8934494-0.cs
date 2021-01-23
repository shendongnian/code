    var myVM = this.DataContext as MyViewModelType;
    if (myVM != null)
    {
        myVM.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "MyXDocumentProperty")
                {
                    this.timeLine.ResetEvents(myVM.MyXDocumentProperty);
                }
            };
    }
