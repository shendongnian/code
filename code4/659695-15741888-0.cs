      void request()
      {
            var db = new DataClasses1(connectionString);
            var result = 
                from a in db.Stats.AsEnumerable()
                where Function(a.SourceName)
                select a;
        }
        bool Function(string sourceName)
        {
            return true;
        }
