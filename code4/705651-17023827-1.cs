            TouchCollection touchCollection = TouchPanel.GetState();
            if (!_touched && touchCollection.Count > 0)
            {
                _touched = false;
                _launchEvent = false;
                foreach (TouchLocation location in touchCollection)
                {
                    for (int i = 0; i < menuButtons.Count; i++)
                    {
                        Button button = menuButtons[i];
                        _touchID = location.Id;
                        _touchPoint = new Point((int)location.Position.X, (int)location.Position.Y);
                        if (GetButtonHitBounds(button).Contains(_touchPoint))
                        {
                            button.SwitchState(true);
                            _selectedButton = button;
                        }
                    }
                }
            }
            else if (touchCollection.Count == 0)
            {
                _touched = false;
                for (int i = 0; i < menuButtons.Count; i++)
                {
                    Button button = menuButtons[i];
                    button.SwitchState(false);
                    if (GetButtonHitBounds(button).Contains(_touchPoint) && _launchEvent)
                    {
                        OnReleased(i, PlayerIndex.One);
                        _launchEvent = false;
                    }
                }
            }
            ///
            // This if statement checks whether the touch is still inside the button area.
            // Then assigns a value of true to the _launchEvent variable.
            //
            // The 'try' block is used because if the first touch is not on button, then the
            // value of the _selectedButton is null and it will throw an exception.
            ///
            if (touchCollection.FindById(_touchID, out _touchLocation))
            {
                if (_touchLocation.State == TouchLocationState.Moved)
                {
                    try
                    {
                        if (GetButtonHitBounds(_selectedButton).Contains((int)_touchLocation.Position.X, (int)_touchLocation.Position.Y))
                            _launchEvent = true;
                        else
                            _launchEvent = false;
                    }
                    catch { }
                }
            }
