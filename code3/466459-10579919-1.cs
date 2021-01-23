    public static IEnumerable<T> AllControls<T>(this Control startingPoint) where T : Control
            {
                if (startingPoint is T)
                    yield return startingPoint as T;
                
                foreach (var item in startingPoint.Controls.Cast<Control>().SelectMany(AllControls<T>))
                    yield return item;
            }
