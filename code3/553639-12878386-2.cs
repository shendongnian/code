    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
    namespace PointerInput
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            Windows.Devices.Input.TouchCapabilities SupportedContacts = new Windows.Devices.Input.TouchCapabilities();
            uint numActiveContacts;
            Dictionary<uint, Windows.UI.Input.PointerPoint> contacts;
            Dictionary<uint, Point> startLocation;
            Dictionary<uint, bool> pointSwiped;
            int swipeThresholdX = 100;
            int swipeThresholdY = 100;
            public MainPage()
            {
                this.InitializeComponent();
                numActiveContacts = 0;
                contacts = new Dictionary<uint, Windows.UI.Input.PointerPoint>((int)SupportedContacts.Contacts);
                startLocation = new Dictionary<uint, Point>((int)SupportedContacts.Contacts);
                pointSwiped = new Dictionary<uint, bool>((int)SupportedContacts.Contacts);
                targetContainer.PointerPressed += new PointerEventHandler(targetContainer_PointerPressed);
                targetContainer.PointerEntered += new PointerEventHandler(targetContainer_PointerEntered);
                targetContainer.PointerReleased += new PointerEventHandler(targetContainer_PointerReleased);
                targetContainer.PointerExited += new PointerEventHandler(targetContainer_PointerExited);
                targetContainer.PointerCanceled += new PointerEventHandler(targetContainer_PointerCanceled);
                targetContainer.PointerCaptureLost += new PointerEventHandler(targetContainer_PointerCaptureLost);
                targetContainer.PointerMoved += new PointerEventHandler(targetContainer_PointerMoved);
            }
            // PointerPressed and PointerReleased events do not always occur in pairs. 
            // Your app should listen for and handle any event that might conclude a pointer down action 
            // (such as PointerExited, PointerCanceled, and PointerCaptureLost).
            void targetContainer_PointerPressed(object sender, PointerRoutedEventArgs e)
            {
                if (Convert.ToBoolean(SupportedContacts.TouchPresent) && (numActiveContacts > SupportedContacts.Contacts))
                {
                    // cannot support more contacts
                    eventLog.Text += "\nNumber of contacts exceeds the number supported by the device.";
                    return;
                }
                Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(targetContainer);
                // Update event sequence.
                eventLog.Text += "\nDown: " + pt.PointerId;
                // Change background color of target when pointer contact detected.
                targetContainer.Fill = new SolidColorBrush(Windows.UI.Colors.Green);
                // Check if pointer already exists (if enter occurred prior to down).
                if (contacts.ContainsKey(pt.PointerId))
                {
                    return;
                }
                contacts[pt.PointerId] = pt;
                startLocation[pt.PointerId] = pt.Position;
                pointSwiped[pt.PointerId] = false;
                ++numActiveContacts;
                e.Handled = true;
                // Display pointer details.
                createInfoPop(e);
            }
            private void targetContainer_PointerEntered(object sender, PointerRoutedEventArgs e)
            {
                Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(targetContainer);
                // Update event sequence.
                eventLog.Text += "\nOver: " + pt.PointerId;
                if (contacts.Count == 0)
                {
                    // Change background color of target when pointer contact detected.
                    targetContainer.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                // Check if pointer already exists (if enter occurred prior to down).
                if (contacts.ContainsKey(pt.PointerId))
                {
                    return;
                }
                // Push new pointer Id onto expando target pointers array.
                contacts[pt.PointerId] = pt;
                startLocation[pt.PointerId] = pt.Position;
                pointSwiped[pt.PointerId] = false;
                ++numActiveContacts;
                e.Handled = true;
                // Display pointer details.
                createInfoPop(e);
            }
            // Fires for for various reasons, including: 
            //    - User interactions
            //    - Programmatic caputre of another pointer
            //    - Captured pointer was deliberately released
            // PointerCaptureLost can fire instead of PointerReleased. 
            private void targetContainer_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
            {
                Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(targetContainer);
                // Update event sequence.
                eventLog.Text += "\nPointer capture lost: " + pt.PointerId;
                if (contacts.ContainsKey(pt.PointerId))
                {
                    checkSwipe();
                    contacts[pt.PointerId] = null;
                    contacts.Remove(pt.PointerId);
                    startLocation.Remove(pt.PointerId);
                    if (pointSwiped.ContainsKey(pt.PointerId))
                        pointSwiped.Remove(pt.PointerId);
                    --numActiveContacts;
                }
                // Update the UI and pointer details.
                foreach (TextBlock tb in pointerInfo.Children)
                {
                    if (tb.Name == e.Pointer.PointerId.ToString())
                    {
                        pointerInfo.Children.Remove(tb);
                    }
                }
                if (contacts.Count == 0)
                {
                    targetContainer.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
                }
                e.Handled = true;
            }
            // Fires for for various reasons, including: 
            //    - A touch contact is canceled by a pen coming into range of the surface.
            //    - The device doesn't report an active contact for more than 100ms.
            //    - The desktop is locked or the user logged off. 
            //    - The number of simultaneous contacts exceeded the number supported by the device.
            private void targetContainer_PointerCanceled(object sender, PointerRoutedEventArgs e)
            {
                Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(targetContainer);
                // Update event sequence.
                eventLog.Text += "\nPointer canceled: " + pt.PointerId;
                if (contacts.ContainsKey(pt.PointerId))
                {
                    checkSwipe();
                    contacts[pt.PointerId] = null;
                    contacts.Remove(pt.PointerId);
                    startLocation.Remove(pt.PointerId);
                    if (pointSwiped.ContainsKey(pt.PointerId))
                        pointSwiped.Remove(pt.PointerId);
                    --numActiveContacts;
                }
                // Update the UI and pointer details.
                foreach (TextBlock tb in pointerInfo.Children)
                {
                    if (tb.Name == e.Pointer.PointerId.ToString())
                    {
                        pointerInfo.Children.Remove(tb);
                    }
                }
                if (contacts.Count == 0)
                {
                    targetContainer.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
                }
                e.Handled = true;
            }
            private void targetContainer_PointerExited(object sender, PointerRoutedEventArgs e)
            {
                Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(targetContainer);
                // Update event sequence.
                eventLog.Text += "\nPointer exited: " + pt.PointerId;
                if (contacts.ContainsKey(pt.PointerId))
                {
                    checkSwipe();
                    contacts[pt.PointerId] = null;
                    contacts.Remove(pt.PointerId);
                    startLocation.Remove(pt.PointerId);
                    if (pointSwiped.ContainsKey(pt.PointerId))
                        pointSwiped.Remove(pt.PointerId);
                    --numActiveContacts;
                }
                // Update the UI and pointer details.
                foreach (TextBlock tb in pointerInfo.Children)
                {
                    if (tb.Name == e.Pointer.PointerId.ToString())
                    {
                        pointerInfo.Children.Remove(tb);
                    }
                }
                if (contacts.Count == 0)
                {
                    targetContainer.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
                }
                e.Handled = true;
            }
            /// <summary>
            /// Invoked when this page is about to be displayed in a Frame.
            /// </summary>
            /// <param name="e">Event data that describes how this page was reached.  The Parameter
            /// property is typically used to configure the page.</param>
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
            }
            void targetContainer_PointerReleased(object sender, PointerRoutedEventArgs e)
            {
                foreach (TextBlock tb in pointerInfo.Children)
                {
                    if (tb.Name == e.Pointer.PointerId.ToString())
                    {
                        pointerInfo.Children.Remove(tb);
                    }
                }
                Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(targetContainer);
                // Update event sequence.
                eventLog.Text += "\nUp: " + pt.PointerId;
                // Change background color of target when pointer contact detected.
                targetContainer.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                if (contacts.ContainsKey(pt.PointerId))
                {
                    checkSwipe();
                    contacts[pt.PointerId] = null;
                    contacts.Remove(pt.PointerId);
                    startLocation.Remove(pt.PointerId);
                    if(pointSwiped.ContainsKey(pt.PointerId))
                        pointSwiped.Remove(pt.PointerId);
                    --numActiveContacts;
                }
                e.Handled = true;
            }
            private void targetContainer_PointerMoved(object sender, PointerRoutedEventArgs e)
            {
                Windows.UI.Input.PointerPoint currentPoint = e.GetCurrentPoint(targetContainer);
                if (currentPoint.IsInContact)
                {
                    if (startLocation.ContainsKey(currentPoint.PointerId))
                    {
                        Point startPoint = startLocation[currentPoint.PointerId];
                        if (Math.Abs(currentPoint.Position.X - startPoint.X) > swipeThresholdX) // I only did one Axis for testing
                        {
                            pointSwiped[currentPoint.PointerId] = true;
                        }
                    }
                }
                updateInfoPop(e);
            }
            int numberOfSwipedFingers()
            {
                int count = 0;
                foreach (var item in pointSwiped)
                {
                    if (item.Value) { count += 1; }
                }
                return count;
            }
            void checkSwipe()
            {
                if (numberOfSwipedFingers() > 1)
                {
                    eventLog.Text += "\nNumber of Swiped fingers = " + numberOfSwipedFingers();
                    pointSwiped.Clear();
                }
                else if (numberOfSwipedFingers() == 1)
                {
                    eventLog.Text += "\nNumber of Swiped fingers = " + numberOfSwipedFingers();
                    pointSwiped.Clear();
                }
            }
            
            void createInfoPop(PointerRoutedEventArgs e)
            {
                Windows.UI.Input.PointerPoint currentPoint = e.GetCurrentPoint(targetContainer);
                TextBlock pointerDetails = new TextBlock();
                pointerDetails.Name = currentPoint.PointerId.ToString();
                pointerDetails.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                pointerInfo.Children.Add(pointerDetails);
                pointerDetails.Text = queryPointer(e);
            }
            void updateInfoPop(PointerRoutedEventArgs e)
            {
                foreach (TextBlock pointerDetails in pointerInfo.Children)
                {
                    if (pointerDetails.Name == e.Pointer.PointerId.ToString())
                    {
                        pointerDetails.Text = queryPointer(e);
                    }
                }
            }
            String queryPointer(PointerRoutedEventArgs e)
            {
                Windows.UI.Input.PointerPoint currentPoint = e.GetCurrentPoint(targetContainer);
                String details = "";
                switch (e.Pointer.PointerDeviceType)
                {
                    case Windows.Devices.Input.PointerDeviceType.Mouse:
                        details += "\nPointer type: mouse";
                        break;
                    case Windows.Devices.Input.PointerDeviceType.Pen:
                        details += "\nPointer type: pen";
                        if (e.Pointer.IsInContact)
                        {
                            details += "\nPressure: " + currentPoint.Properties.Pressure;
                            details += "\nrotation: " + currentPoint.Properties.Orientation;
                            details += "\nTilt X: " + currentPoint.Properties.XTilt;
                            details += "\nTilt Y: " + currentPoint.Properties.YTilt;
                            details += "\nBarrel button pressed: " + currentPoint.Properties.IsBarrelButtonPressed;
                        }
                        break;
                    case Windows.Devices.Input.PointerDeviceType.Touch:
                        details += "\nPointer type: touch";
                        details += "\nrotation: " + currentPoint.Properties.Orientation;
                        details += "\nTilt X: " + currentPoint.Properties.XTilt;
                        details += "\nTilt Y: " + currentPoint.Properties.YTilt;
                        break;
                    default:
                        details += "\nPointer type: n/a";
                        break;
                }
                GeneralTransform gt = targetContainer.TransformToVisual(page);
                Point screenPoint;
                screenPoint = gt.TransformPoint(new Point(currentPoint.Position.X, currentPoint.Position.Y));
                details += "\nPointer Id: " + currentPoint.PointerId.ToString() +
                    "\nPointer location (parent): " + currentPoint.Position.X + ", " + currentPoint.Position.Y +
                    "\nPointer location (screen): " + screenPoint.X + ", " + screenPoint.Y;
                return details;
            }
        }
    }
