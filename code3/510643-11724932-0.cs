        public static int Foo(int index)
        {
            var nowNum = 1;
            var nowIndex = 0;
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
