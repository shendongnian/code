    using (StreamWriter sw1 = new StreamWriter("E:\\testing\\check1.txt"))
    {
        if (condition)
        {
            foreach (Type type in asm1.GetTypes())
            {
                if (contition)
                {
                    sw1.WriteLine("verification point was set and the test passed");
                }
            }
        }
}
