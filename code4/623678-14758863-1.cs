    decimal[] decArray = new decimal[5];
    int _indexCount = 0;
   
    private void btnCalculate_Click(object sender, EventArgs e)
    {
        ...
        if (decArray.Count() == _indexCount)
        {
            var elementHolder = decArray;
            decArray = new T[(decArray.Length + 1) * 2];
            for (int i = 0; i < elementHolder.Length; i++)
            {
                decArray[i] = elementHolder[i];
            }
        }
        decArray[_indexCount] = invoiceTotal;
        _indexCount++;
    }
