    private DelegateCommand _save;
    public ICommand SaveCommand
    {
      get {return this._save ?? (this._save = new DelegateComamnd(this.MyExecuteMethod, this.MyCanExecuteMethod));}
     }
    private bool MyCanExecuteMethod()
    {
       return this.WeekDays.Any(x=>x.IsSelected) && string.IsNullOrWhiteSpace(this.Error);
    }
