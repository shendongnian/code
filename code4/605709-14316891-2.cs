       public partial class Foo
       {
            public Foo()
            {
                this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
                    {
                        if (!e.PropertyName.EndsWith("Specified"))
                        {
                            var prop = this.GetType().GetProperty(e.PropertyName + "Specified");
                            if (prop != null)
                                prop.SetValue(this, true, null);
                        }
                    };
            }
        }
