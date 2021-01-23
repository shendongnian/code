        public void Run()
        {
            var s = new SomeObject();
            var weakS = new WeakReference(s);
            s = null;
            GC.Collect();
            if (weakS.IsAlive) throw new Exception();
        }
