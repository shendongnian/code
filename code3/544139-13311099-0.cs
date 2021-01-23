    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    namespace Microsoft.Research.DynamicDataDisplay.ViewportRestrictions {
    /// <summary>
    /// Represents a restriction, which limits the maximal size of <see cref="Viewport"/>'s Visible property.
    /// </summary>
    public class ZoomInRestriction : ViewportRestriction {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaximalSizeRestriction"/> class.
        /// </summary>
        public ZoomInRestriction() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MaximalSizeRestriction"/> class with the given maximal size of Viewport's Visible.
        /// </summary>
        /// <param name="maxSize">Maximal size of Viewport's Visible.</param>
        public ZoomInRestriction(double height, double width) {
            Height = height;
            Width = width;
        }
        private double height;
        private double width;
        public double Height {
            get { return height; }
            set {
                if (height != value) {
                    height = value;
                    RaiseChanged();
                }
            }
        }
        public double Width {
            get { return width; }
            set {
                if (width != value) {
                    width = value;
                    RaiseChanged();
                }
            }
        }
        /// <summary>
        /// Applies the specified old data rect.
        /// </summary>
        /// <param name="oldDataRect">The old data rect.</param>
        /// <param name="newDataRect">The new data rect.</param>
        /// <param name="viewport">The viewport.</param>
        /// <returns></returns>
        public override DataRect Apply(DataRect oldDataRect, DataRect newDataRect, Viewport2D viewport) {
            if ((newDataRect.Width < width || newDataRect.Height < height)) {
                return oldDataRect;
            }
            return newDataRect;
        }
    }
    }
