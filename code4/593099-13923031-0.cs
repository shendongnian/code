        public static class InputEventArgsExtensions
        {
            public static Point GetPosition<T>(this T e, IInputElement obj)
                where T : InputEventArgs
            {
                if (e is MouseEventArgs)
                    return (e as MouseEventArgs).GetPosition(obj);
                else if (e is TouchEventArgs)
                    return (e as TouchEventArgs).GetTouchPoint(obj).Position;
                return new Point();
            }
        }
