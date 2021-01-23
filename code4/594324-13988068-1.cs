    namespace NetBlast.Runtime.PlatformInvoke.Windows
    {
        #region USING
    
        using System;
        using System.Collections.Generic;
        using System.Drawing;
        using System.Linq;
        using System.Text;
    
        #endregion
    
        /// <summary>
        /// The Rect (RECT) structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
        /// </summary>
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Rect : IEquatable<Rect>, IEquatable<Rectangle>, ICloneable
        {
            #region CONSTANTS
    
    
    
            #endregion
    
            #region VARIABLES
    
            /// <summary>
            /// Win32 RECT.left value.
            /// </summary>
            private int left;
    
            /// <summary>
            /// Win32 RECT.top value.
            /// </summary>
            private int top;
    
            /// <summary>
            /// Win32 RECT.right value.
            /// </summary>
            private int right;
    
            /// <summary>
            /// Win32 RECT.bottom value.
            /// </summary>
            private int bottom;
    
            #endregion
    
            #region PROPERTIES
    
            /// <summary>
            /// Gets or sets the x-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public Int32 Left
            {
                get { return this.left; }
                set { this.left = value; }
            }
    
            /// <summary>
            /// Gets or sets the y-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public Int32 Top
            {
                get { return this.top; }
                set { this.top = value; }
            }
    
            /// <summary>
            /// Gets or sets the x-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public Int32 Right
            {
                get { return this.right; }
                set { this.right = value; }
            }
    
            /// <summary>
            /// Gets or sets the y-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public Int32 Bottom
            {
                get { return this.bottom; }
                set { this.bottom = value; }
            }
    
            /// <summary>
            /// Gets or sets the height of the rectangle.
            /// </summary>
            public Int32 Height
            {
                get { return this.bottom - this.top; }
                set { this.bottom = value + this.top; }
            }
    
            /// <summary>
            /// Gets or sets the width of the rectangle.
            /// </summary>
            public Int32 Width
            {
                get { return this.right - this.left; }
                set { this.right = value + this.left; }
            }
    
            /// <summary>
            /// Gets or sets the top, left location of the rectangle.
            /// </summary>
            public Point Location
            {
                get
                {
                    return new Point(this.left, this.top);
                }
    
                set
                {
                    this.right = this.left - value.X;
                    this.bottom = this.top - value.Y;
                    this.left = value.X;
                    this.top = value.Y;
                }
            }
    
            /// <summary>
            /// Gets or sets the size of the rectangle.
            /// </summary>
            public Size Size
            {
                get
                {
                    return new Size(this.Width, this.Height);
                }
    
                set
                {
                    this.right = value.Width + this.left;
                    this.bottom = value.Height + this.top;
                }
            }
    
            #endregion
    
            #region CONSTRUCTORS / FINALIZERS
    
            /// <summary>
            /// Initializes a new instance of the <see cref="Rect" /> struct.
            /// </summary>
            /// <param name="location">The top, left location of the rectangle.</param>
            /// <param name="size">The size of the rectangle.</param>
            public Rect(Point location, Size size)
            {
                this.left = default(int);
                this.top = default(int);
                this.right = default(int);
                this.bottom = default(int);
                this.Location = location;
                this.Size = size;
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="Rect" /> struct.
            /// </summary>
            /// <param name="left">The x-coordinate of the upper-left corner of the rectangle.</param>
            /// <param name="top">The y-coordinate of the upper-left corner of the rectangle.</param>
            /// <param name="right">The x-coordinate of the lower-right corner of the rectangle.</param>
            /// <param name="bottom">The y-coordinate of the lower-right corner of the rectangle.</param>
            public Rect(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
    
            #endregion
    
            #region OPERATORS
    
            /// <summary>
            /// Provides implicit casting from Rect to Rectangle.
            /// </summary>
            /// <param name="rectangle">The Rect instance to cast.</param>
            /// <returns>A Rectangle representation of the Rect instance.</returns>
            public static implicit operator Rectangle(Rect rectangle)
            {
                return new Rectangle(rectangle.Location, rectangle.Size);
            }
    
            /// <summary>
            /// Provides implicit casting from Rectangle to Rect.
            /// </summary>
            /// <param name="rectangle">The Rectangle instance to cast.</param>
            /// <returns>A Rect representation of the Rectangle instance.</returns>
            public static implicit operator Rect(Rectangle rectangle)
            {
                return new Rect(rectangle.Location, rectangle.Size);
            }
    
            /// <summary>
            /// Performs an equality check between two instances of Rect.
            /// </summary>
            /// <param name="a">Instance a of Rect.</param>
            /// <param name="b">Instance b of Rect.</param>
            /// <returns>True if the instances are equal, otherwise false.</returns>
            public static bool operator ==(Rect a, Rect b)
            {
                return a.Equals(b);
            }
    
            /// <summary>
            /// Performs an inequality check between two instances of Rect.
            /// </summary>
            /// <param name="a">Instance a of Rect.</param>
            /// <param name="b">Instance b of Rect.</param>
            /// <returns>True if the instances are not equal, otherwise false.</returns>
            public static bool operator !=(Rect a, Rect b)
            {
                return !a.Equals(b);
            }
    
            #endregion
    
            #region STATIC METHODS
    
    
    
            #endregion
    
            #region INSTANCE METHODS
    
            /// <summary>
            /// Indicates whether the current object is equal to another object of the same type.
            /// </summary>
            /// <param name="obj">An object to compare with this object.</param>
            /// <returns>True if the instances are not equal, otherwise false.</returns>
            public override bool Equals(object obj)
            {
                return this.Equals((Rect)obj);
            }
    
            /// <summary>
            /// Serves as a hash function for this instance of Rect.
            /// </summary>
            /// <returns>A hash code for the current Rect.</returns>
            public override int GetHashCode()
            {
                return ObjectUtilities.CreateHashCode(this.left, this.top, this.right, this.bottom);
            }
    
            /// <summary>
            /// Returns a string representation of this instance.
            /// </summary>
            /// <returns>A string representation of this instance.</returns>
            public override string ToString()
            {
                return string.Format("Left: {0}; Top: {1}; Right: {2}; Bottom: {3};", this.left, this.top, this.right, this.bottom);
            }
    
            /// <summary>
            /// Indicates whether the current object is equal to another object of the same type.
            /// </summary>
            /// <param name="other">A Rect instance to compare with this object.</param>
            /// <returns>True if the instances are not equal, otherwise false.</returns>
            public bool Equals(Rect other)
            {
                return this.left == other.left
                    && this.top == other.top
                    && this.right == other.right
                    && this.bottom == other.bottom;
            }
    
            /// <summary>
            /// Indicates whether the current object is equal to another object of the same type.
            /// </summary>
            /// <param name="other">A Rectangle instance to compare with this object.</param>
            /// <returns>True if the instances are not equal, otherwise false.</returns>
            public bool Equals(Rectangle other)
            {
                return this.left == other.Left
                    && this.top == other.Top
                    && this.right == other.Right
                    && this.bottom == other.Bottom;
            }
    
            /// <summary>
            /// Returns a clone of this Rect instance.
            /// </summary>
            /// <returns>A clone of this Rect instance.</returns>
            public object Clone()
            {
                return new Rect(this.left, this.top, this.right, this.bottom);
            }
    
            #endregion
    
            #region DELEGATES & EVENTS
    
    
    
            #endregion
    
            #region CLASSES & STRUCTURES
    
    
    
            #endregion
        }
    }
