    public static class Shape
    {
        public static int GetNumVerts(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Triangle:return 3;
                case ShapeType.Square:return 4;
                //...
            }
        }
    }
