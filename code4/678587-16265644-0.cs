    public void RandomList()
    {
        stack = new Stack<int>(); 
        while (loop)
        {
            if (lbxStackRndNum.InvokeRequired)
            {
                lbxStackRndNum.Invoke(new MethodInvoker(delegate
                    {
                        Random rnd = new Random();
                        if (lbxStackRndNum.Items.Count == 10)
                        {
                            stack.Clear();
                            lbxStackRndNum.Items.Clear();
                        }
                        int rndVal = rnd.Next(1, 10000);
                        stack.Push(rndVal);
                        lbxStackRndNum.Items.Insert(0, rndVal);
                    }));
                  Thread.Sleep(1000);
            }
        }
    }
