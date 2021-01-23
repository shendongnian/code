    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using rekie;
    namespace System.Collections.Generic
    {
      public static class FilterExtension
      {
        private static string _criteria;
        public static IList<Node> FilterBy(this IList<Node> source, string criteria)
        {
          _criteria = criteria;
          var copySource =
            (from n in source
             select n).ToList();
          foreach (var node in source)
          {
            if (node.Offspring != null)
            {
              FilterRecursion(node);
            }
          }
          return copySource;
        }
        private static void FilterRecursion(Node parent)
        {
          foreach (var node in parent.Offspring)
          {
            if (node.Offspring != null)
            {
              FilterRecursion(node);
            }
            node.Visible = node.Text.Contains(_criteria);
          }
          parent.Visible = parent.Text.Contains(_criteria) || parent.Offspring.Where(o => o.Visible).Count() > 0;
        }
      }
    }
    namespace rekie
    {
  
      class Program
      {
        static void Main(string[] args)
        {
          var orig = Node.GetSome();
          var Results = orig.FilterBy("O.o");
        }
      }
      public class Node
      {
        public string Text { get; set; }
        public IList<Node> Offspring { get; set; }
        public bool Visible { get; set; }
        public static IList<Node> GetSome()
        {
          return
            new List<Node>()
            { 
              new Node()
              { 
                Text="Chidori", 
                Offspring=new List<Node>()
                  { 
                    new Node(){ Text="Rasengan "}
                  }
              }, 
              new Node()
              { 
                Text="Kage Shuriken no Jutsu", 
                Offspring=new List<Node>()
                {
                  new Node(){Text="Amagumo O.o"}
                }
              }, 
              new Node()
              { 
                Text="Kage Bunshin no Jutsu", 
                Offspring=new List<Node>()
              }, 
              new Node()
              { 
                Text="Oiroke no Jutsu", 
                Offspring=new List<Node>()
                {
                  new Node(){ Text="O.o"}
                }
              }, 
              new Node()
              { 
                Text="Ranshinsho O.o", 
                Offspring=new List<Node>()
                {
                  new Node(){ Text="Shikotsumyaku" },
                  new Node(){ Text="Byakugan"}
                }
              }
            };
        }
      }
    }
