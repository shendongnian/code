    for (int i = 0; i < effect.Techniques.Count; i++)
    {
        for (int j = 0; j < effect.Techniques[i].Passes.Count; j++)
        {
            effect.Techniques[i].Passes[j].Apply();
            quad.RenderFullScreenQuad(effect); 
        }
    }
