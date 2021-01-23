    private void InitExpanders()
    {
        var expanders = GetExpanders();
        int x = 0;
        for (int i = 0; i < expanders.Count; i++)
        {
            if (i % 6 == 1)
            {
                    int y = x++;
                    expanders[i - 1].Expanded += delegate
                    {
                        DisableBigExpanders(y);
                    };
            }
        }
    }
