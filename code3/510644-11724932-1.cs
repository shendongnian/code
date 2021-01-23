            public static long F(long index)
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
    
                long nowNum = 1;
                long nowIndex = 0;
                while (nowIndex < index)
                {
                    nowIndex += nowNum;
                    if (nowIndex <= index)
                    {
                        nowNum++;
                    }
                }
                return nowNum;
            }
