    public static void SysMain( [[params]] )
    {
      using (Application app = new UserApp( [[params]] )) // UserApp derives from Application
      {
        app.Start(); // Virtual method
        app.AllowNext(); // Base method--see text
        app.Run(); // Abstract method
      }
    }
