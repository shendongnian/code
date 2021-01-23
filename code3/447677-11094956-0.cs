     TouchPanel.EnabledGestures = GestureType.Tap | GestureType.DragComplete;
                foreach (GestureSample gestureSample in input.Gestures)
                {
                    if (gestureSample.GestureType == GestureType.Tap)
                    {
                        Debug.WriteLine("tapped  ");
                    }
                    else if (gestureSample.GestureType == GestureType.DragComplete)
                    {
                        Debug.WriteLine("dragged");
                    }
                }
