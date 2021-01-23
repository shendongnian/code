            messageBox.Dismissed += (s1, e1) =>
            {
                switch (e1.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        {
                            delete = true ;
                        }
                        break;
                    case CustomMessageBoxResult.RightButton:
                        break;
                    case CustomMessageBoxResult.None:
                        break;
                    default:
                        break;
                }
            };
            messageBox.Unloaded += (s1, e1) =>
            {
                if (delete)
                    DeleteWorkout();
            };
