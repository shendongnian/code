    private void btnSort_Click(object sender, EventArgs e)
    {
        Random r = new Random();
        int n = 10;
        int[] iar = new int[n];
        //Generate random numbers and store them in the Unsorted ListBox
        for (int i = 0; i < iar.Length; i++)
        {
            iar[i] = r.Next(0, 20);
            lb1.Items.Add(iar[i]);
        }
        
        //Sort the random numbers array
        Quicksort(iar, 0, iar.Length - 1);
        //Now the array is sorted put it in the Sorted Listbox
        for (int i = 0; i < iar.Length; i++)
        {
            lb2.Items.Add(iar[i]);
        }
    }
