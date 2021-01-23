    sb.Begin(); //spritebatch
    RectangleSprite.DrawRectangle(sb, new Rectangle(10, 10, 50, 100), Color.Red, 1);
    RectangleSprite.DrawRectangle(sb, new Rectangle(30, 20, 80, 15), Color.Green, 4);
    RectangleSprite.DrawRectangle(sb, new Rectangle(70, 40, 40, 70), Color.Blue, 6);
    sb.End();
