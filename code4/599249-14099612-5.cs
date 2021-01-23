    static class BackgroundFactory{
      static public AbstractBackground Create(BackgroundFactoryType type, Cursor cursor, ContentManager content)
      {
        switch (type)
        {
          case BackgroundFactoryType.Special:
            return new SpecialBackground(cursor, content);
          case BackgroundFactoryType.Image:
            return new ImageBackground(content);
          case BackgroundFactoryType.Normal:
            return new NormalBackground();
          default:
            throw new ArgumentException("the type is bogus");
        }
      }
    }
