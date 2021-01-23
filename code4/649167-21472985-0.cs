             protected SQLiteConnection ReadableDB
             {
                 get{return new SQLiteConnection(ReadableDatabase.Path);}
              }
             protected SQLiteConnection WriteableDB
             {
                 get{return new SQLiteConnection(WritableDatabase.Path);
             }
