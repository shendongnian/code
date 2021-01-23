    Translate Rotate90Cw(Translate moveFunction)
    {
        return Rotate(moveFunction, Math.PI / 2.0);
    }
    Translate Rotate(Translate moveFunction, double angle)
    {
        Point tempPoint = moveFunction(new Point(0, 0));
        double sin = Math.Sin(angle);
        double cos = Math.Cos(angle);
        return p => new Point(p.X + tempPoint.X * cos + tempPoint.Y * sin,
                               p.Y - tempPoint.X * sin + tempPoint.Y * cos);
    }
