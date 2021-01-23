    interface IPerson{}
    class SomePerson : IPerson{}
    class OtherPerson : IPerson{}
    interface IPersonFactory{
        void IPerson Create();
    }
    class SomePersonFactory : IPersonFactory{
        public void IPerson Create(){ return new SomePerson(); }
    }
    class OtherPersonFactory : IPersonFactory{
        public void IPerson Create(){ return new OtherPerson(); }
    }
