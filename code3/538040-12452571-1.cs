            if (!isLoading)
            {
                if (input.Gestures.Count > 0)
                {
                    if (input.Gestures[0].GestureType == GestureType.Tap)
                    {
                        LoadResources();
                    }
                }
            }
