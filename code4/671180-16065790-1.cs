    [Designer(typeof(TestComponentDesigner))]
    public class TestComponent : Component {
      public class TestComponentDesigner : ComponentDesigner {
        private DesignerVerbCollection verbs = new DesignerVerbCollection();
        public override void Initialize(IComponent component) {
          base.Initialize(component);
          verbs.Add(new DesignerVerb("Say Hello", new EventHandler(SayHello)));
        }
        public override DesignerVerbCollection Verbs {
          get {
            return verbs;
          }
        }
        private void SayHello(object sender, EventArgs e) {
          MessageBox.Show("Hello");
        }
      }
    }
