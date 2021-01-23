    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.UI.ApplicationSettings;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Navigation;
    namespace MyApp.Common
    {
        [Windows.Foundation.Metadata.WebHostHidden]
        public class MyAppBasePage : MyApp.Common.LayoutAwarePage
        {
            public MyAppBasePage()
            {
            }
            private bool isSettingCharmEventRegistered;
            // Used to determine the correct height to ensure our custom UI fills the screen.
            private Rect windowBounds;
            // Desired width for the settings UI. UI guidelines specify this should be 346 or 646 depending on your needs.
            private double settingsWidth = 646;
            // This is the container that will hold our custom content.
            private Popup settingsPopup;
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                base.OnNavigatedFrom(e);
                // Added to make sure the event handler for CommandsRequested is cleaned up before other scenarios.
                if (this.isSettingCharmEventRegistered)
                {
                    SettingsPane.GetForCurrentView().CommandsRequested -= onCommandsRequested;
                    this.isSettingCharmEventRegistered = false;
                }
                // Unregister the event that listens for events when the window size is updated.
                Window.Current.SizeChanged -= OnWindowSizeChanged;
            }
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
                windowBounds = Window.Current.Bounds;
                // Added to listen for events when the window size is updated.
                Window.Current.SizeChanged += OnWindowSizeChanged;
                // Added to make sure the event handler for CommandsRequested is cleaned up before other scenarios.
                if (!this.isSettingCharmEventRegistered)
                {
                    SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
                    this.isSettingCharmEventRegistered = true;
                }
            }
            /// <summary>
            /// Invoked when the window size is updated.
            /// </summary>
            /// <param name="sender">Instance that triggered the event.</param>
            /// <param name="e">Event data describing the conditions that led to the event.</param>
            void OnWindowSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
            {
                windowBounds = Window.Current.Bounds;
            }
            /// <summary>
            /// We use the window's activated event to force closing the Popup since a user maybe interacted with
            /// something that didn't normally trigger an obvious dismiss.
            /// </summary>
            /// <param name="sender">Instance that triggered the event.</param>
            /// <param name="e">Event data describing the conditions that led to the event.</param>
            private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
            {
                if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
                {
                    settingsPopup.IsOpen = false;
                }
            }
            /// <summary>
            /// When the Popup closes we no longer need to monitor activation changes.
            /// </summary>
            /// <param name="sender">Instance that triggered the event.</param>
            /// <param name="e">Event data describing the conditions that led to the event.</param>
            void OnPopupClosed(object sender, object e)
            {
                Window.Current.Activated -= OnWindowActivated;
            }
            /// <summary>
            /// This event is generated when the user opens the settings pane. During this event, append your
            /// SettingsCommand objects to the available ApplicationCommands vector to make them available to the
            /// SettingsPange UI.
            /// </summary>
            /// <param name="settingsPane">Instance that triggered the event.</param>
            /// <param name="eventArgs">Event data describing the conditions that led to the event.</param>
            void onCommandsRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs eventArgs)
            {
                UICommandInvokedHandler handler = new UICommandInvokedHandler(onSettingsCommand);
                SettingsCommand generalCommand = new SettingsCommand("DefaultsId", "Defaults", handler);
                eventArgs.Request.ApplicationCommands.Add(generalCommand);
            }
            /// <summary>
            /// This the event handler for the "Defaults" button added to the settings charm. This method
            /// is responsible for creating the Popup window will use as the container for our settings Flyout.
            /// The reason we use a Popup is that it gives us the "light dismiss" behavior that when a user clicks away 
            /// from our custom UI it just dismisses.  This is a principle in the Settings experience and you see the
            /// same behavior in other experiences like AppBar. 
            /// </summary>
            /// <param name="command"></param>
            void onSettingsCommand(IUICommand command)
            {
                // Create a Popup window which will contain our flyout.
                settingsPopup = new Popup();
                settingsPopup.Closed += OnPopupClosed;
                Window.Current.Activated += OnWindowActivated;
                settingsPopup.IsLightDismissEnabled = true;
                settingsPopup.Width = settingsWidth;
                settingsPopup.Height = windowBounds.Height;
                // Add the proper animation for the panel.
                settingsPopup.ChildTransitions = new TransitionCollection();
                settingsPopup.ChildTransitions.Add(new PaneThemeTransition()
                {
                    Edge = (SettingsPane.Edge == SettingsEdgeLocation.Right) ?
                           EdgeTransitionLocation.Right :
                           EdgeTransitionLocation.Left
                });
                // Create a SettingsFlyout the same dimenssions as the Popup.
                SettingsFlyout mypane = new SettingsFlyout();
                mypane.Width = settingsWidth;
                mypane.Height = windowBounds.Height;
                // Place the SettingsFlyout inside our Popup window.
                settingsPopup.Child = mypane;
                // Let's define the location of our Popup.
                settingsPopup.SetValue(Canvas.LeftProperty, SettingsPane.Edge == SettingsEdgeLocation.Right ? (windowBounds.Width - settingsWidth) : 0);
                settingsPopup.SetValue(Canvas.TopProperty, 0);
                settingsPopup.IsOpen = true;
            }
        }
    }
