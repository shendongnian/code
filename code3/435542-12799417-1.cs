     switch (e.GestureType)
                {
                    case GestureType.Menu:
                        Debug.WriteLine("Menu");
                        Gesture = "Menu";
                        break;
                    case GestureType.WaveRight:
                        Debug.WriteLine("Wave Right");
                        Gesture = "Wave Right";
                        break;
                    case GestureType.WaveLeft:
                        Debug.WriteLine("Wave Left");
                        Gesture = "Wave Left";
                        break;
                    case GestureType.JoinedHands:
                        Debug.WriteLine("Joined Hands");
                        Gesture = "Joined Hands";
                        break;
                    case GestureType.SwipeLeft:
                        Debug.WriteLine("Swipe Left");
                        Gesture = "Swipe Left";
                        break;
                    case GestureType.SwipeRight:
                        Debug.WriteLine("Swipe Right");
                        Gesture = "Swipe Right";
                        break;
                    case GestureType.ZoomIn:
                        Debug.WriteLine("Zoom In");
                        Gesture = "Zoom In";
                        break;
                    case GestureType.ZoomOut:
                        Debug.WriteLine("Zoom Out");
                        Gesture = "Zoom Out";
                        break;
    
                    default:
                        break;
