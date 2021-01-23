    // private HashSet<int> seen = new HashSet<int>();
    // private Random random = new Random(); 
    if (seen.Count == imageList1.Images.Count)
    {
        // no cards left...
    }
    
    int card = random.Next(0, imageList1.Images.Count);
    while (!seen.Add(card))
    {
        card = random.Next(0, imageList1.Images.Count);
    }
    pictureBox1.Image = imageList1.Images[card];
