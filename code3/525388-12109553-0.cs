        static bool IsNaN(dynamic d)
        {
            float dub;
            try
            {
                dub = (float)d;
                return float.IsNaN(dub);
            }
            catch (RuntimeBinderException)
            {
            }
            return false;
        }
