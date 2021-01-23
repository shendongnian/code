        private static void ProcessMessage(PointMessage arg)
        {
            if (...)
            {
                ...
                arg.ID++;
                _block.Post(arg);
            }
            else
            {
                 ...
                _block.Post(arg);
            }
        }
