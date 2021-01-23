     using System.Reflection;
          
       ...
          Uri NavUri = //your tile's navigation URI
          ShellTileData data = //your tile's data
          
          object[] parameters = { NavUri, data};
          Type[] types = new[] { typeof(Uri), typeof(ShellTileData)};
          Type type = typeof(ShellTile);
          MethodInfo info = type.GetMethod("Create", types);
          info.Invoke(null, parameters);
