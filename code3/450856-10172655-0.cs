    public void test()
    {
          for (int i = 0; i < 10000; i++)
          {
              System.Threading.Thread.Sleep(1000);
              label1.Text = i.ToString();
          }
    }
