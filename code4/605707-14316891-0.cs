    public partial class Foo
    {
        public Foo()
        {
            this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
                {
                    if (!e.PropertyName.EndsWith("Specified"))
                        this.GetType().GetProperty(e.PropertyName + "Specified").SetValue(this, true, null);
                };
        }
