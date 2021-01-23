        public class MyRect //class so you can inherit from it, but you could make your own struct as well
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Right { get { return X + Width; } }
            public int Bottom{ get { return Y + Height; } }
            public static implicit operator Rectangle(MyRect rect)
            {
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            }
            public static implicit operator MyRect(Rectangle rect)
            {
                return new MyRect { X = rect.X, Y = rect.Y, Width = rect.Width, Height = rect.Height };
            }
        }       
     }
