    namespace SvetlinAnkov.examples
    {
        public class MyCompositeControl : Control
        {
            public MyCompositeControl()
            {
                DefaultStyleKey = typeof(MyCompositeControl);
            }
            protected override void OnManipulationStarted(
                ManipulationStartedEventArgs e)
            {
                Debug.WriteLine("OnManipulationStarted");
            }
        }
    }
