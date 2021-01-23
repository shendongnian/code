    public double[] GetRow(int rowNumber)
    {
        var result = new double[this.Content.GetLength(0)];
        for(var i=0; i<result.Length; i++)
        {
            result[i] = this.Content[rowNumber, i];
        }
        return result;
    }
