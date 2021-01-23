    public class CheckBoxClass
    {
     public int Index {get; set;}
     public string DisplayText {get; set}
     private bool _checked;
     public bool Checked 
     {
       get { return _checked;}
       set {
            _checked = value
            doSomethingWhenChecked();
           }
    }
    ObservableCollection<CheckBoxClass> CollectionOfObjectsThatRepresentYourCheckBox = SomeMethodThatPopulatesIt();
