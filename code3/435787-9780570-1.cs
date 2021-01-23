    float weight = 1.0f;
    for (int i = 0; i < points.Length; ++i)
    {
        if (weights != null)
        {
            weight = weights[i].Weight;
        }
    
        x += points[i].X * weight;
        y += points[i].Y * weight;
        z += points[i].Z * weight;
    
        wtotal += weight;
    }
