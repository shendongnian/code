     Dictionary<int, Vertice> vertices = new Dictionary<int, Vertice>();
    
                for (int i = 1; i < vertices.Length; i++)
                {
                    if (vertices.ContainsKey(vertices[i]))
                    {
                        indices.Add(vertices[i]);
                    }
                    if (vertices.ContainsKey(vertices[i - 1]))
                    {
                        indices.Add(vertices[i - 1]);
                    }
                    if (vertices.ContainsKey(vertices[middle]))
                    {
                        indices.Add(vertices[middle]);
                    }
                }
