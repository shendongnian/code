    public void Update(TimeSpan elapsedTime, List<Shape> shapes, Shape fallingShape)
        {
            List<Shape> shapesInSameColumn = new List<Shape>();
    
            //Added code.
            if (currentShape.State == ShapeState.Landed)
            {
                Shape shape = new Shape();
                shape = utilities.GetRandomShape(contentManager);
                shapes.Add(shape);
                currentShape = shape;
            }
    
            foreach (var shape in shapes)
            {
                if (shape.ColumnNumber == fallingShape.ColumnNumber)
                {
                    shapesInSameColumn.Add(shape);
                }
            }
    
            shapesInSameColumn.Remove(fallingShape);
            float yDestination = 0f;
            float yNextPosition = fallingShape.Position.Y + elapsedTime.Milliseconds / 30 * FallSpeed;
    
            if (shapesInSameColumn.Count == 0) // There are NO shapes in the column
            {
                yDestination = Utilities.bottomOfCanvas;
                if (yNextPosition > yDestination)
                {
                    fallingShape.Position.Y = yDestination;
                    fallingShape.State = ShapeState.Landed;
                    return;
                }
                else
                {
                    fallingShape.Position.Y = yNextPosition;
                }
            }
            else // There ARE shapes in the column
            {
                yDestination = shapesInSameColumn[shapesInSameColumn.Count - 1].Position.Y - Texture.Height;
    
                if (yNextPosition > yDestination)
                {
                    fallingShape.Position.Y = yDestination;
                    fallingShape.State = ShapeState.Landed;
                    return;
                }
                else
                {
                    fallingShape.Position.Y = yNextPosition;
                }
            }
        }
