    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace SO16390592
    {
        class Program
        {
            static void Main()
            {
                ISelectSingleSpace test = new Test();
                test.AvailableSpaces = new List<Space>(new Space[1]);
                test.DoStuff();
            }
        }
        public class Space
        {
            
        }
        
        public interface ISelectSpace
        {
            bool ShowSpaceSelection { get; set; }
            IEnumerable<Space> AvailableSpaces { get; set; }
        }
        public interface ISelectSingleSpace : ISelectSpace
        {
            string Space { get; set; }
            string SpaceName { get; set; }
        }
        public class Test : ISelectSingleSpace
        {
            public bool ShowSpaceSelection { get; set; }
            public IEnumerable<Space> AvailableSpaces { get; set; }
            public string Space { get; set; }
            public string SpaceName { get; set; }
        }
        public static class SelectSingleSpace
        {
            public static void DoStuff(this ISelectSingleSpace selectSingleSpace)
            {
                Console.Write(selectSingleSpace.AvailableSpaces.Count());
            }
        }
    }
