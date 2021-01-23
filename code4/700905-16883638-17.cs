    class Parser
    {
        static class RedBankSpecification : ISpecification<XElement>
        {
            public override bool IsSatisfiedBy(XElement element)
            {
                return element.Value.equals("RED");
            }
        }
        public void Parse(XDocument doc)
        {
            var rspec = new RedBankSpecification();
            foreach(XElement e in doc)
            {
                if (r.IsSatisfiedBy(e))
                {
                    IRedBank bank = new RedBank(e);
                    bankFacade.Send(bank);
                }
            }
            //...
        }
    }
