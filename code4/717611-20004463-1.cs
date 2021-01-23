 C#
App.Current.Dispatcher.BeginInvoke((Action)delegate()
{
    yourCommand.RaiseCanExecuteChanged();
});
I didn't really like the idea of having to call RaiseCanExecuteChanged in multiple places, so i ended up using this:
2) i.  I added to the Constructor:  
 C#
this.PropertyChanged+=my_PropertyChanged;
ii.
 C#
private void me_PropertyChanged(object sender, PropertyChangedEventArgs e)
{
    switch (e.PropertyName)
    {
        case "whateverPropertyNamethatcontrolsit":
            ((RelayCommand)FirstCommand).RaiseCanExecuteChanged();
            break;
    }
}
iii. inside the task:
 C#
App.Current.Dispatcher.BeginInvoke((Action)delegate()
{
    whateverProperty=something;
});
Note i was using MVVMLight with RelayCommand, but DelegateCommand instead of RelayCommand works too.
