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
                   lineB = line;
    //               XFormMain.SetStatus(lineb);
                   System.Console.Write(line); 
                }
            }
        }
