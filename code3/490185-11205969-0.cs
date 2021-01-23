    public class MyControl : UserControl {
            public ICommand FirstButtonCommand {
                get;
                set;
            }
            public ICommand SecondButtonCommand {
                get;
                set;
            }
            public Action OnExecuteFirst {
                get;
                set;
            }
            public Action OnExecuteSecond {
                get;
                set;
            }
    
            public MyControl() {
                FirstButtonCommand = new MyCommand(OnExecuteFirst);
                FirstButtonCommand = new MyCommand(OnExecuteSecond);
            }
        }
