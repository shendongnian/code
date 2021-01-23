    public static class Shape
    {
        public static int GetNumVerts(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Triangle:return Triangle.GetNumVerts();
                case ShapeType.Square:return Square.GetNumVerts();
                //...
            }
        }
    }
