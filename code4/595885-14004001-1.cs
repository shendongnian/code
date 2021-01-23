        public void Inferred()
        {
            C c = new C();
            var v = Factory3.CreateFactory(c).Create(c); // type is Tuple<C, Other<string>>
        }
