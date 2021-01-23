    public class DoubleTap {
        delegate void ActionFunction();
        Control ReferencedControl;
        public DoubleTap ( ref Control referencedControl , delegate actionFunction ) {
            ActionFunction = actionFunction;
            ReferencedControl = referencedControl;
            // apply TouchDown and TouchUp event handlers to ReferencedControl
        }
        // Put your TouchDown and TouchUp functions for testing the double tap here
        // when double tap tests as true then call ActionFunction();
    }
