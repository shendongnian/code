            public static long Foo(long index)
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
    
                long nowNum = 0;
                long nowIndex = 0;
                do
                {
                    nowIndex += nowNum;
                    nowNum++;
                } while (nowIndex < index);
                return nowNum;
            }
