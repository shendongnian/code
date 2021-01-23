    public static void process() 
    {
      // possible because of public class with static public members
      using(StreamWriter mgraph = new StreamWriter(gen.m_graph_file))
      {
         // do your processing...
      }
    }
