            // Create a Popup window which will contain our flyout.
            _providerPopup = new Popup
                                 {
                                     Height = Window.Current.Bounds.Height,
                                     ChildTransitions = new TransitionCollection
                                                            {
                                                                new PaneThemeTransition
                                                                    {
                                                                        Edge =
                                                                            (SettingsPane.Edge ==
                                                                             SettingsEdgeLocation.Right)
                                                                                ? EdgeTransitionLocation.Right
                                                                                : EdgeTransitionLocation.Left
                                                                    }
                                                            }
                                 };
            // Add the proper animation for the panel.
            // Create a SettingsFlyout the same dimenssions as the Popup.
            var mypane = new CreateProvider {Height = Window.Current.Bounds.Height};
            // Place the SettingsFlyout inside our Popup window.
            _providerPopup.Child = mypane;
            // Let's define the location of our Popup.
            _providerPopup.SetValue(Canvas.LeftProperty,
                                    SettingsPane.Edge == SettingsEdgeLocation.Right
                                        ? (Window.Current.Bounds.Width - SettingsWidth)
                                        : 0);
            _providerPopup.SetValue(Canvas.TopProperty, 0);
            _providerPopup.IsOpen = true;
