        private void changeButtonState()
        {
            if (_isPressed)
            {
                _state = "Pressed";
                _isPressed = false;
            }
            else
            {
                _state = "Normal";
                _isPressed = true;
            }
            VisualStateManager.GoToState(btnClick, _state, true);
        }
 
