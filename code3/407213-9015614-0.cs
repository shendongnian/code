    class MyUIElement : UIElement
        {
            protected override void OnManipulationStarting(System.Windows.Input.ManipulationStartingEventArgs e)
            {
                base.OnManipulationStarting(e);
                UIElement involvedUIElement = e.Source as UIElement;
                // to cancel the touch manipulaiton:
                e.Cancel();
            }
        }
