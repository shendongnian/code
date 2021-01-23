    for (int i = 1; i < circleVect.Length; i++)
    {
        for (int j = 0; j < vertices.Count; j++)
        {
            var v3 = vertices[j]; 
            if (v3 == circleVect[i] || v3 == circleVect[i - 1] || v3 == middle)
                indices.Add(j);
        }
    }
