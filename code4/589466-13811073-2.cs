            public class FooEvents {
                public event EventHandler ConstructDesign;
                public DataGridView dataGrid = new DataGridView();
                public FooEvents(Action action) {
                    ConstructDesign+=action;
                    dataGrid.DataBindingComplete+=ConstructDesign;
                    dataGrid.DataBindingComplete+=RemoveSubscribtion;
                }
                public void Launch() {
                    ConstructDesign(this, new EventArgs()); //passes FooEvent and fires.
                }
                private void RemoveSubscribtion(object sender, EventArgs args) {
                     dataGrid.DataBindingComplete-=ConstructDesign;
                     dataGrid.DataBindingComplete-=RemoveSubscribtion;
                }
           public Main {
                public void Main(string[] args) {
                    var launcher = new FooClass(Fire);
                    launcher.Launch();
                }
               
                public void Fire(object sender, EventHandlerArgs args) {
                    Console.WriteLine("Fired");
                }
           }
