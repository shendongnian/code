        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new DelegateCommand(Exit);
                    exitCommand.GestureKey = Key.X;
                    exitCommand.GestureModifier = ModifierKeys.Control;
                    exitCommand.MouseGesture = MouseAction.LeftDoubleClick;
                }
                return exitCommand;
            }
        }
     private void Exit()
        {
            Application.Current.Shutdown();
        }
 
