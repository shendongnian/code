    internal class Entities
    {
        private Dictionary<ListKey, List<string>> _liststDict =
          new Dictionary<ListKey, List<string>>
            {
              {ListKey.Cm, new List<string> {"CM12", "CM701", "CM901/CM30", "CM901K", "CM1101", "CM1101K"}},
              {ListKey.MultiB, new List<string> {"Multi650/450", "Multi660/630", "Multi650/800", "Multi650/1000"}},
              {ListKey.Multi01, new List<string> {"Multi301", "Multi601", "Multi801", "Multi1001"}}
            };
    
        public List<string> GetList(ListKey key)
        {
          return _liststDict[key];
        }
    
        internal enum ListKey
        {
          Cm,
          MultiB,
          Multi01
        }
    }
    
    
    internal class EntitiesTester
    {
        public static void Do()
        {
          Entities entities = new Entities();
    
          Console.Out.WriteLine("CM count = {0}", entities.GetList(Entities.ListKey.Cm).Count);
          Console.Out.WriteLine("MultiB count = {0}", entities.GetList(Entities.ListKey.MultiB).Count);
          Console.Out.WriteLine("Multi01 count = {0}", entities.GetList(Entities.ListKey.Multi01).Count);
        }
    }
