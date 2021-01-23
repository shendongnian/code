    namespace N
    {
      class Mammal
      {
        // contains nested type of an unfortunate name
        internal interface Giraffe
        {
        }
      }
      class Giraffe : Mammal
      {
        Giraffe g;  // what's the fully qualified name of the type of g?
      }
    }
