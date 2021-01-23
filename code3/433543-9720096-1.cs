    public class Area {
            private Level[,] _activeLevels; //3x3 array of the current level and surrounding ones.
            IEnumerable<object> Objects {
                get {
                    foreach (Level lvl in _activeLevels)
                        foreach (object o in lvl.Objects)
                            yield return o;
                    
                }
            }
        }
