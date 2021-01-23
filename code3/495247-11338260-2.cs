    public void SetListFloatKey(string key, List<float> Values)
    {
        StringBuilder sb = new StringBuilder();
        foreach (float value in Values)
        {
            sb.Add(string.Format("{0},", value));
        }
        SetKey(key, sb.ToString());
    }
