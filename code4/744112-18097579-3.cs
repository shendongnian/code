    private List<places> deserialize_places(List<string> l)
            {
                List<places> liste = new List<places>();
                foreach(string s in l){
                    liste.Add((places)Tools.Deserialize(s, typeof(places)));
                }
                return liste;
            }
    
            private List<string> serialize_places(List<places> l)
            {
                List<string> liste = new List<string>();
                foreach (places s in l)
                {
                    liste.Add(Tools.Serialize(s));
                }
                return liste;
            }
