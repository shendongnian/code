        class Lines : System.Collections.IEnumerable {
            // Variables
            private ArrayList lines;
        
            // Constructor
            public Lines() {
                lines = new ArrayList();
            }
        
            public void Add(string line) {
                lines.Add(line);
            }
        
            // Iterator
            public System.Collections.IEnumerator GetEnumerator() {
                for (int i = 0; i < lines.Count; i++) {
                    yield return lines[i];
                }
            }
        
            public void Print() {
                string lineB = "";
                foreach (string line in lines)
                {
                   lineB = line; // now this line errors
    //               XFormMain.SetStatus(lineb); // and this line doesn't
                   System.Console.Write(line); // this line doesn't in either situation
                }
            }
        }
