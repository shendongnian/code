            public class FooEvents {
                public event EventHandler ConstructDesign;
                public DataGridView dataGrid = new DataGridView();
                public FooEvents(Action action) {
                    ConstructDesign+=action;
                    dataGrid.DataBindingComplete+=ConstructDesign;
                }
                public void Launch() {
                    ConstructDesign(this, new EventArgs()); //passes FooEvent and fires.
                }
                public void RemoveEvent() {
                    if (dataGrid.DataBindingComplete != null)
                         dataGrid.DataBindingComplete-=ConstructDesign;
                }
           public Main {
                public void Main(string[] args) {
                    var launcher = new FooClass(Fire);
                    launcher.Launch();
                }
               
                public void Fire(object sender, EventHandlerArgs args) {
                    FooEvents foo = (FooEvents) sender;
                    foo.RemoveEvent();
                    Console.WriteLine("Fired");
                }
           }
