    class junk
    {
        private IDisposable somevar;
        void SomeFunc()
        {
            using (somevar = SomeOtherFunc())
            {
               YesAnotherFunc();
            }
        }
    }
