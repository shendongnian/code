        /// <summary>
        /// Gets the relative position of the given UIElement to this.
        /// </summary>
        public static Point GetRelativePosition(this UIElement element, UIElement other)
        {
            return element.TransformToVisual(other)
                          .Transform(new Point(0, 0));
        }
