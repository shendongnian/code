    using System.Collections;
    
    namespace A
    {
      class Top : IDisposable, // importing System.Collections also imports System   
                  IEnumerable, // inside the imported namespace
                  System.Collections.Generic.IEnumerable<int>
      {…}                      // ^ "using" does not permit namespace abbreviation
    }
    
    namespace A.B
    {
      class Middle : Top,      // namespace A available inside namespace A.B
                     C.IBottom // namespace blocks permit namespace abbreviation
      {…}
    }
    
    namespace A.B.C
    {
      interface IBottom {…}
    }
