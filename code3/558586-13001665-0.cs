        void CpuIntensive()
        {
            var startDt = DateTime.Now;
            while (true)
            {
                if ((DateTime.Now - startDt).TotalSeconds >= 10)
                    break;
            }
        }
