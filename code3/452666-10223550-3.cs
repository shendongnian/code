    public void Draw(Graphics g)
    {
      g.DrawEllipse(_pen, _point.X - _radius, _point.Y - _radius, 2 * _radius, 2 * _radius);
      g.DrawLine(_pen, _point, _point.Add(_forwardVector.Multiply(_vectorLength)));
    }
    public void MoveForward()
    {
      _point = _point.Add(_forwardVector);
    }
