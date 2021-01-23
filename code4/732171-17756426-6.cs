    interface IWithValue {
        string Value { get; }
    }
    class ControlCompanion<T>: IWithValue where T: Control {
      IFunc<Control, string> fetcher;
      public T Control { get; private set; }
      public string Value { get { return fetcher(Control); } }
 
      public ControlCompanion (T control, IFunc<T, string> fetcher) {
        Control = control;
        this.fetcher = fetcher;
      }
    }
    
    // this is typed narrowly here, but it could be typed wider to
    // the actual ControlCompanion if needing additional information
    // or actions wrt. the particular control
    var valueAccessors = new List<IWithValue>();
    var textBox = new TextBox();
    valueAccessors.Add(new ControlCompanion(textBox, (c) => c.Text));
    var comboBox = new ComboBox();
    valueAccessors.Add(new ControlCompanion(textBox, (c) => c.SelectedValue));
    var allValues = valueAccessors.Select(v => v.Value);
