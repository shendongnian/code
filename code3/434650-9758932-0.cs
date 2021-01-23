    class SafeFileEnumerator : IEnumerable<string>
    {
      private string root;
      private string pattern;
      private IList<Exception> errors;
      public SafeFileEnumerator(string root, string pattern)
      {
         this.root = root;
         this.pattern = pattern;
         this.errors = new List<Exception>();
      }
      public SafeFileEnumerator(string root, string pattern, IList<Exception> errors)
      {
         this.root = root;
         this.pattern = pattern;
         this.errors = errors;
      }
      public Exception[] Errors()
      {
         return errors.ToArray();
      }
      class Enumerator : IEnumerator<string>
      {
         IEnumerator<string> fileEnumerator;
         IEnumerator<string> directoryEnumerator;
         string root;
         string pattern;
         IList<Exception> errors;
         public Enumerator(string root, string pattern, IList<Exception> errors)
         {
            this.root = root;
            this.pattern = pattern;
            this.errors = errors;
            fileEnumerator = System.IO.Directory.EnumerateFiles(root, pattern).GetEnumerator();
            directoryEnumerator = System.IO.Directory.EnumerateDirectories(root).GetEnumerator();
         }
         public string Current
         {
            get
            {
               if (fileEnumerator == null) throw new ObjectDisposedException("FileEnumerator");
               return fileEnumerator.Current;
            }
         }
         public void Dispose()
         {
            if (fileEnumerator != null)
               fileEnumerator.Dispose();
            fileEnumerator = null;
            if (directoryEnumerator != null)
               directoryEnumerator.Dispose();
            directoryEnumerator = null;
         }
         object System.Collections.IEnumerator.Current
         {
            get { return Current; }
         }
         public bool MoveNext()
         {
            if ((fileEnumerator != null) && (fileEnumerator.MoveNext()))
               return true;
            while ((directoryEnumerator != null) && (directoryEnumerator.MoveNext()))
            {
               if (fileEnumerator != null)
                  fileEnumerator.Dispose();
               try
               {
                  fileEnumerator = new SafeFileEnumerator(directoryEnumerator.Current, pattern, errors).GetEnumerator();
               }
               catch (Exception ex)
               {
                  errors.Add(ex);
                  continue;
               }
               if (fileEnumerator.MoveNext())
                  return true;
            }
            if (fileEnumerator != null)
               fileEnumerator.Dispose();
            fileEnumerator = null;
            if (directoryEnumerator != null)
               directoryEnumerator.Dispose();
            directoryEnumerator = null;
            return false;
         }
         public void Reset()
         {
            Dispose();
            fileEnumerator = System.IO.Directory.EnumerateFiles(root, pattern).GetEnumerator();
            directoryEnumerator = System.IO.Directory.EnumerateDirectories(root).GetEnumerator();
         }
      }
      public IEnumerator<string> GetEnumerator()
      {
         return new Enumerator(root, pattern, errors);
      }
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
    }
