            if (e.WindowActivationState == CoreWindowActivationState.CodeActivated)
            {
                if (BottomAppBarWasOpenBeforeCharmsActivated)
                {
                    BottomAppBar.IsSticky = true;
                    BottomAppBar.IsOpen = true;
                    BottomAppBarWasOpenBeforeCharmsActivated = false;
                }
            }
            if (e.WindowActivationState == CoreWindowActivationState.Deactivated)
            {
                if (BottomAppBar.IsOpen == true)
                {
                    BottomAppBarWasOpenBeforeCharmsActivated = true;
                    BottomAppBar.IsSticky = false;
                    BottomAppBar.IsOpen = false;
                }
            }
        }
