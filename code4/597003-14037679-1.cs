    Double[] array = new Double[listBox1.Items.Count];
    for (int i = 0; i < listBox1.Items.count; i++)
        array[k] = Convert.ToDouble(listBox1.Items[i]);
    int count = 2 ^ array.Items.Count;
    List<Double>[] listNumber = new List<Double>[count];
    for (int i = 0; i < listNumber.Items.Count; i++) {
        listNumber[i] = new List<Double>();
        for (j = 0; j < array.Items.Count)
            if (i & (1 << j) != 0)
                listNumber[i].Add(array[j]);
    }
