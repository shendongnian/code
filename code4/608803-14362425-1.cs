        public void processDisposables<T1, T2>(T1 type1, T2 type2, Action<T1, T2> action)
            where T1: IDisposable
            where T2: IDisposable {
                try {
                    action(type1, type2);
                } finally {
                    type1.Dispose();
                    type2.Dispose();
                }
        }
