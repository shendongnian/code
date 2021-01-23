    public class CheckboxControlVM
      {
        bool _isChecked = false;
        string _name ;
      public Property<bool> IsChecked { get { return _isChecked} set { _isChecked=value;} }
      public Property<string> Name { get { return _name } set { _name =value;} }
      public CheckboxControlVM(bool isChecked, string name)
      {
        _isChecked = isChecked;
         _name = name;
        IsChecked = new Property<bool>(_isChecked);
        Name = new Property<string>(_name);
      }
    }
