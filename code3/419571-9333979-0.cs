    bool MouseWithinRotatedRectangle(Rectangle area, Vector2 tmp_mousePosition, float angleRotation)
    {
        Vector2 mousePosition = tmp_mousePosition - currentSquare.Origin;
        float mouseOriginalAngle = (float)Math.Atan(mousePosition.Y / mousePosition.X);
        mousePosition = new Vector2((float)(Math.Cos(-angleRotation + mouseOriginalAngle) * mousePosition.Length()), 
                                    (float)(Math.Sin(-angleRotation + mouseOriginalAngle) * , mousePosition.Length()));
        return area.Contains(mousePosition);
    }
