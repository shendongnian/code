    internal sealed class DrawParams
    {
       private SpriteBatch mSpriteBatch;
       private bool mBegin;
       /// <summary>Calls SpriteBatch.Begin if the begin value is true. Always call this in a draw method; use the return value to determine whether you should call EndDraw.</summary>
       /// <returns>A value indicating whether or not begin was called, and thus whether or not you should call end.</returns>
       public bool BeginDraw()
       {
          bool rBegin = mBegin;
          if (mBegin)
          {
             mSpriteBatch.Begin();
             mBegin = false;
          }
          return rBegin;
       }
       /// <summary>Always calls SpriteBatch.End. Use the return value of BeginDraw to determine if you should call this method after drawing.</summary>
       public void EndDraw()
       {
          mSpriteBatch.End();
       }
    }
