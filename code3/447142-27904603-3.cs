     private class ColumnNode: Node
            {
                public string NodeControl1="";  // This sould make the DataPropertyName specified in the Node Collection.
                public string NodeControl2 = "";
                public string NodeControl3 = "";
                public ColumnNode(string nodeControl1, string nodeControl2, int nodeControl3)
                {
                    NodeControl1 = nodeControl1;
                    NodeControl2 = nodeControl2;
                    NodeControl3 = nodeControl3.ToString();
                }
            }
