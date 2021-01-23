    public void Test()
    {
      var p = new Position(8, 3);
      var p2 = p.With(t => t.X, 4);
      var p3 = p.With(t => t.Y, 7).With(t => t.X, 5);
      Console.WriteLine(p);
      Console.WriteLine(p2);
      Console.WriteLine(p3);
    }
    public struct Position
    {
      public Position(int X, int Y)
      {
        this._X = X; this._Y = Y;
      }
      private int _X; private int _Y;
      public int X { get { return _X; } private set { _X = value; } }
      public int Y { get { return _Y; } private set { _Y = value; } }
      public Position With<T, P>(Expression<Func<Position, P>> propertyExpression, T value)
      {
        // Copy this
        var copy = (Position)this.MemberwiseClone();
        // Get the expression, might be both MemberExpression and UnaryExpression
        var memExpr = propertyExpression.Body as MemberExpression ?? ((UnaryExpression)propertyExpression.Body).Operand as MemberExpression;
        if (memExpr == null)
          throw new Exception("Empty expression!");
        // Get the propertyinfo, we need this one to set the value
        var propInfo = memExpr.Member as PropertyInfo;
        if (propInfo == null)
          throw new Exception("Not a valid expression!");
        // Set the value via boxing and unboxing (mutable structs are evil :) )
        object copyObj = copy;
        propInfo.SetValue(copyObj, value); // Since struct are passed by value we must box it
        copy = (Position)copyObj;
        // Return the copy
        return copy;
      }
      public override string ToString()
      {
        return string.Format("X:{0,4} Y:{1,4}", this.X, this.Y);
      }
    }
