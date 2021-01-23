    // base type
    interface IFoo {
      int ID { get; set; }
    }
      // generic method
      public List<T> Update<T>(List<T> graph1, List<T> graph2) where T : IFoo {
        var update = graph1.Intersect(graph2, (g1, g2) => { g1.ID == g2.ID }).ToList();
        return update;
      }
