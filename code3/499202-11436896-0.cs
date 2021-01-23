    public void Foo<T>(T param)
        {
            dynamic xx = param;
            this.Bar(param);
        }
        private void Bar<T>(T param) where T: class {
        }
