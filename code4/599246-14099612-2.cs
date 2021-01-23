    enum BackgroundFactoryType
    {
      Special,
      Image,
      Normal,
    }
     static class BackgroundFactory{
  
        static Dictionary<BackgroundFactoryType, Func<Cursor, ContentManager, AbstractBackground>> constructors;
        static BackgroundFactory()
        {
           //initialize the constructor funcs
           constructors = new Dictionary<BackgroundFactoryType, Func<Cursor, ContentManager, AbstractBackground>>();
           constructors.Add(BackgroundFactoryType.Special, (cursor, content) => new SpecialBackground(cursor, content));
           constructors.Add(BackgroundFactoryType.Image, (_, content) => new ImageBackground(content));
           constructors.Add(BackgroundFactoryType.Normal, (_, __) => new NormalBackground());
        }
           
        static public AbstractBackground Create(BackgroundFactoryType type, Cursor cursor, ContentManager content){
          if (!constructors.ContainsKey(type))
               throw new ArgumentException("the type is bogus");
          return constructors[type](cursor, content);
        }
    
        //or you could simply do:
        static public AbstractBackground Create(BackgroundFactoryType type, Cursor cursor, ContentManager content){
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
