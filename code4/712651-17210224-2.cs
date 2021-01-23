    public class class1 {
      public string string1;
      public class class2 {
        private class1 _Reference;
        public class1 Reference {
          set { _Reference = value; }
        }
        public string string2 {
          get { return _Reference.string1; }
        }
      }
    }
    static void usage() {
      var foo = new class1();
      var bar = new class1.class2();
      bar.Reference = foo;
      string value = bar.string2;
    }
 
